using UnityEngine;

public class TargetSpawnController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public GameObject Target;

    [Header("Spawning")]
    [SerializeField] private FirstPersonController firstPersonController;
    public int startingTargetCount;
    public float minRadius = 4.0f;
    public float maxRadius = 4.0f;
    public float minHeight = -1.0f;
    public float maxHeight = 3.0f;
    public int difficulty = 1;


    void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {         
        Quaternion targetRotation = new Quaternion(180,180,0,1);
        GameObject instantiatedObject = Instantiate(Target, new Vector3(0,0,0), targetRotation);
        instantiatedObject.SetActive(true);
        
    }

    void Update()
    {
        if (firstPersonController.score == 25 && difficulty == 1 || firstPersonController.score == 50 && difficulty == 2 || firstPersonController.score == 100 && difficulty == 3 || firstPersonController.score == 175 && difficulty == 4  )
        {
            SpawnTarget();
            difficulty++;
        }

    }

    

}
