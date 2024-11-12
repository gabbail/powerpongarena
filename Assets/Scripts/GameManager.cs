using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameMode currentMode = GameMode.Classic;

    private BallMovement ball;

    private void Start()
    {
        switch (currentMode)
        {
            case GameMode.Classic:
                ball.SetClassicMode();
                break;
            case GameMode.SpeedRush:
                ball.SetSpeedRushMode();
                break;
        }
    }

    public void SwitchGameMode(GameMode newMode)
    {
        currentMode = newMode;

        switch (currentMode)
        {
            case GameMode.Classic:
                ball.SetClassicMode();
                break;
            case GameMode.SpeedRush:
                ball.SetSpeedRushMode();
                break;
        }
    }
}