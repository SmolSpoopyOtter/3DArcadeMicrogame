using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Mouse Look")]
    public Transform cameraPivot;
    public float mouseSensitivity = 120f;
    public float minPitch = -75f;
    public float maxPitch = 75f;
    [Header("Game Values")]
    public float score = 24;
    [SerializeField] private UnityEvent targetHit;
    private float pitch; // up/down rotation
    private float range = 20f; 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
                targetHit.Invoke();
                score++;
            }
            else 
            {
                Debug.Log("Haw Haw you missed loser");    
            }
        }
    }
}