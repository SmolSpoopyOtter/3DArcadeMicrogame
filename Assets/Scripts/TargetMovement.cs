using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TargetMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private FirstPersonController firstPersonController;
    private float[] SpawningRules = { 0, 0, 0 };
    private Vector3 startPosition;
    public int lives = 3;
    private bool returnStart = false;
    public UnityEvent<bool> Respawn;
    private float speed = 4f;
    void Start()
    {
        DifficultyScale();
        targetPosition = new Vector3(Random.Range(4f, 5f), Random.Range(0.8f, SpawningRules[0]), Random.Range(SpawningRules[1], SpawningRules[2]));
        startPosition = new Vector3(targetPosition.x, 0, targetPosition.z);
        transform.position = new Vector3(targetPosition.x, 0, targetPosition.z);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.01 && returnStart == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, targetPosition) < 0.01 && returnStart == false)
        {
            StartCoroutine(StayStill());
        }
        if (returnStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, startPosition) < 0.01 && returnStart == true)
        {
            Respawn.Invoke(true);
            Destroy(gameObject);
        }

    }

    void DifficultyScale()
    {
        SpawningRules[0] = Mathf.Clamp(2f * (1 + firstPersonController.score / 125), 0.8f, 3.0f);
        SpawningRules[1] = Mathf.Clamp(-(1.5f * (1 + firstPersonController.score / 125)), -3.0f, -1.5f);
        SpawningRules[2] = Mathf.Clamp(1.5f * (1 + firstPersonController.score / 125), 1.5f, 3.0f);
    }

    IEnumerator StayStill()
    {
        yield return new WaitForSeconds(5/(1 + firstPersonController.score / 125));
        returnStart = true;
    }
}
