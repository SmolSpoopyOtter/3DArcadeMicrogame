using UnityEngine;
using UnityEngine.Events;

public class TargetSpawnController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public GameObject Target;

    [Header("Spawning")]
    [SerializeField] private FirstPersonController firstPersonController;
    public UnityEvent<int> UpdateLives;
    public int startingTargetCount;
    public float minRadius = 4.0f;
    public float maxRadius = 4.0f;
    public float minHeight = -1.0f;
    public float maxHeight = 3.0f;
    public int difficulty = 1;
    public int lives = 3;


    void Start()
    {
        SpawnTarget(false);
    }

    public void SpawnTarget(bool fellNaturally)
    {
        if (lives > 0)
        {
            Quaternion targetRotation = new Quaternion(0, 0, 0, 1);
            GameObject instantiatedObject = Instantiate(Target, new Vector3(0, 0, 0), targetRotation);
            instantiatedObject.SetActive(true);
        }
        
        if (fellNaturally == true)
        {
            lives -= 1;
            UpdateLives.Invoke(lives);
        }
    }

    void Update()
    {
        if (firstPersonController.score == 10 && difficulty == 1 || firstPersonController.score == 60 && difficulty == 2 || firstPersonController.score == 125 && difficulty == 3 || firstPersonController.score == 250 && difficulty == 4  )
        {
            SpawnTarget(false);
            difficulty++;
        }

    }

    

}
