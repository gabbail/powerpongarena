using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadClassic()
    {
        SceneManager.LoadScene(Levels.Classic.ToString());
    }

    public void LoadSpeedRush()
    {
        SceneManager.LoadScene(Levels.SpeedRush.ToString());
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}