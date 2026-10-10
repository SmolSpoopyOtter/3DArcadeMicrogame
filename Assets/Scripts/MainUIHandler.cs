using TMPro;
using UnityEngine;

public class MainUIHandler : MonoBehaviour
{
    [Header("UIElements")]
    [SerializeField] private TextMeshProUGUI SensitivityText;
    [SerializeField] private GameObject SettingsGUI;
    [SerializeField] private GameObject MainMenuGUI;
    [SerializeField] private GameObject OnboardingGUI;
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

    public void ChangeMenu(int toggle)
    {
        if (toggle == 0)
        {
            SettingsGUI.SetActive(true);
            MainMenuGUI.SetActive(false);
            OnboardingGUI.SetActive(false);
            toggle = 3;
        }
        else if (toggle == 1)
        {
            SettingsGUI.SetActive(false);
            MainMenuGUI.SetActive(true);
            OnboardingGUI.SetActive(false);
            toggle = 3;
        }
        else if (toggle == 2)
        {
            SettingsGUI.SetActive(false);
            MainMenuGUI.SetActive(false);
            OnboardingGUI.SetActive(true);
            toggle = 3;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
