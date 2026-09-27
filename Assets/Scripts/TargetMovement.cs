using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TargetMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private bool returnStart = false;
    public UnityEvent Respawn;
    private float speed = 4f;
    void Start()
    {
        targetPosition = new Vector3(Random.Range(4f,5f), Random.Range(0.8f,3.5f), Random.Range(-3f,3f));
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
            Debug.Log("Feels the aura");
        }
        if (returnStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            
        }

        if (Vector3.Distance(transform.position, startPosition) < 0.01 && returnStart == true)
        {
            Respawn.Invoke();
            Destroy(gameObject);
        }
        
    }

    IEnumerator StayStill()
    {
        yield return new WaitForSeconds(3);
        returnStart = true;
    }
}
