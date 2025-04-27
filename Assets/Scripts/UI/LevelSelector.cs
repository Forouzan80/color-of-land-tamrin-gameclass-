using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadGreyLand()
    {
        SceneManager.LoadScene("GreyLand");
    }

    public void LoadGreenForest()
    {
        SceneManager.LoadScene("GreenForest");
    }

    public void LoadYellowCity()
    {
        SceneManager.LoadScene("YellowCity");
    }

    public void LoadBlackCastle()
    {
        SceneManager.LoadScene("BlackCastle");
    }
}
