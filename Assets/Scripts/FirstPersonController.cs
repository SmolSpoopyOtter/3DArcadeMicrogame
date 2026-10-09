using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Mouse Look")]
    public Transform cameraPivot;
    public float mouseSensitivity;
    public float minPitch = -75f;
    public float maxPitch = 75f;
    [Header("Game Values")]
    public float score = 0;
    public float misses = 0;
    public bool dataSwitch;
    [SerializeField] private UnityEvent<float,bool> populateData;
    [SerializeField] private UnityEvent<bool> targetHit;
    private float pitch;
    private float range = 100f;
    [Header("UI Elements")]
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TextMeshProUGUI HitNMissText;
    [SerializeField] private TextMeshProUGUI AccuracyText;
    void Start()
    {
        print(PlayerPrefs.GetFloat("Sensitivity") * 1000);
        mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity")*1000;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        Look();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInformation;

        if (Physics.Raycast(ray, out hitInformation, range))
        {

            if (hitInformation.collider.CompareTag("Target"))
            {
                dataSwitch = true;
                score++;
                populateData.Invoke(score, dataSwitch);
                targetHit.Invoke(false);
                Destroy(hitInformation.collider.gameObject);
            }
            else 
            {
                misses++;
                dataSwitch = false;
                populateData.Invoke(misses, dataSwitch);
            }
        }
    }

    public void PopulateGameOverUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameOverScreen.SetActive(true);
        HitNMissText.text = $"Hits: {score} Misses: {misses}";
        AccuracyText.text = $"Your accuracy was: {Mathf.Ceil((score / (score + misses)) * 100)}%";
    }
}