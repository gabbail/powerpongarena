using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Resume()
    {
        GameManager.Instance.UnPauseGame();
    }

    public void ReplayClassic()
    {
        SceneManager.LoadScene(Levels.Classic.ToString());
    }

    public void ReplaySpeedRush()
    {
        SceneManager.LoadScene(Levels.SpeedRush.ToString());
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(Levels.MainMenu.ToString());
    }

    public void EnableButtons()
    {
        foreach (Button button in buttons)
        {
            button.enabled = true;
        }
    }

    public void DisableButtons()
    {
        foreach (Button button in buttons)
        {
            button.enabled = false;
        }
    }
}