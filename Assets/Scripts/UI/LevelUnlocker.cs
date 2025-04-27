using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;

    void Start()
    {
        // همیشه مرحله 1 بازه (نیازی به کد نداره)

        // بررسی باز بودن مرحله 2
        if (PlayerPrefs.GetInt("Level2Unlocked", 0) == 1)
            level2Button.interactable = true;
        else
            level2Button.interactable = false;

        // بررسی باز بودن مرحله 3
        if (PlayerPrefs.GetInt("Level3Unlocked", 0) == 1)
            level3Button.interactable = true;
        else
            level3Button.interactable = false;

        // بررسی باز بودن مرحله 4
        if (PlayerPrefs.GetInt("Level4Unlocked", 0) == 1)
            level4Button.interactable = true;
        else
            level4Button.interactable = false;
    }
}
