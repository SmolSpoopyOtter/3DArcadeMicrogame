using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadNextScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
