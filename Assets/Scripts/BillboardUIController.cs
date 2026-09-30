using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BillboardUIController : MonoBehaviour
{
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro missesText;
    [SerializeField] private GameObject life1;
    [SerializeField] private GameObject life2;
    [SerializeField] private GameObject life3;

    public void Start()
    {
        life1.SetActive(false);
        life2.SetActive(false);
        life3.SetActive(false);
    }
    public void UpdateText(float data, bool dataSwitch)
    {
        if (dataSwitch == true)
        {
            scoreText.text = $"Score: {data}";
        }
        else if (dataSwitch == false)
        {
            missesText.text = $"Misses: {data}";
        }
        
    }

    public void UpdateLives(int lives)
    {
        if (lives == 2)
        {
            life1.SetActive(true);
        }
        else if (lives == 1)
        {
            life2.SetActive(true);
        }
        else if (lives == 0)
        {
            life3.SetActive(true);
        }
    }
}
