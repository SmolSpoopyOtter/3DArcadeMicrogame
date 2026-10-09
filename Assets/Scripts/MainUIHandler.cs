using TMPro;
using UnityEngine;

public class MainUIHandler : MonoBehaviour
{
    [Header("UIElements")]
    [SerializeField] private TextMeshProUGUI SensitivityText;
    [SerializeField] private GameObject SettingsGUI;
    [SerializeField] private GameObject MainMenuGUI;
    private void Start()
    {
        if (PlayerPrefs.GetFloat("Sensitivity") < 0.075f) UpdateSensitivity(0.075f);
        else UpdateSensitivity(PlayerPrefs.GetFloat("Sensitivity"));
    }
    public void UpdateSensitivity(float UpdatedSense)
    {
        PlayerPrefs.SetFloat("Sensitivity", UpdatedSense);
        SensitivityText.text = $"Sensitivity: {UpdatedSense}";
        PlayerPrefs.Save();
        print(PlayerPrefs.GetFloat("Sensitivity") * 1000);
    }

    public void OpenSettingsMenu(bool toggle)
    {
        if (toggle == false)
        {
            SettingsGUI.SetActive(true);
            MainMenuGUI.SetActive(false);
            toggle = true;
        }
        else if (toggle == true)
        {
            SettingsGUI.SetActive(false);
            MainMenuGUI.SetActive(true);
            toggle = false;
        }
    }
}
