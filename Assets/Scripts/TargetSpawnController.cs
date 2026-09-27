using UnityEngine;

public class TargetSpawnController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public GameObject Target;

    [Header("Spawning")]
    public int startingTargetCount = 1;
    public float minRadius = 4.0f;
    public float maxRadius = 4.0f;
    public float minHeight = -1.0f;
    public float maxHeight = 3.0f;


    void Start()
    {
        for (int i = 0; i < startingTargetCount; i++)
        {
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {         
        Quaternion targetRotation = new Quaternion(180,180,0,1);
        GameObject instantiatedObject = Instantiate(Target, new Vector3(0,0,0), targetRotation);
        instantiatedObject.SetActive(true);
    }


}
