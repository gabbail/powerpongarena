using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameMode currentMode = GameMode.Classic;

    private float startGameWaitTime = 0.5f;

    [SerializeField] private BallMovement ball;
    [SerializeField] private PlayerMovement player1;
    [SerializeField] private PlayerMovement player2;

    public bool gameStarted {get; private set;}

    private int blueSideScore = 0;
    private int redSideScore = 0;

    public event Action<int> blueScored;
    public event Action<int> redScored;

    private void Awake()
    {
        gameStarted = false;
    }

    private void Start()
    {
        switch (currentMode)
        {
            case GameMode.Classic:
                ball.SetClassicMode();
                StartCoroutine(StartGame());
                break;
            case GameMode.SpeedRush:
                ball.SetSpeedRushMode();
                StartCoroutine(StartGame());
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

    public void BlueSideScored()
    {
        blueSideScore++;
        blueScored?.Invoke(blueSideScore);
        ResetGame();
    }

    public void RedSideScored()
    {
        redSideScore++;
        redScored?.Invoke(redSideScore);
        ResetGame();
    }

    private void ResetGame()
    {
        player1.Reset();
        player2.Reset();
        ball.Reset();
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(startGameWaitTime);

        gameStarted = true;
        ball.Launch();
    }
}