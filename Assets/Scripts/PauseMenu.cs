using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onPaused;
    [Header("Interface Elements")]
    [SerializeField] private GameObject pauseMenu;

    private bool paused = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            onPaused.Invoke(paused);
            Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = paused;
            Time.timeScale = paused ? 0f : 1f;
            pauseMenu.SetActive(paused);
        }
    }

    public void Resume()
    {
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        onPaused.Invoke(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
