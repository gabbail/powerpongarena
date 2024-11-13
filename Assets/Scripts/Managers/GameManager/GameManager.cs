using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameMode currentMode = GameMode.Classic;
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameOverMenu gameOverMenu;

    private float startGameWaitTime = 1f;

    [SerializeField] private BallMovement ball;
    [SerializeField] private PlayerMovement player1;
    [SerializeField] private PlayerMovement player2;
    
    private int blueSideScore = 0;
    private int redSideScore = 0;
    private int scoreLimit = 10;

    public event Action<int> blueScored;
    public event Action<int> redScored;

    public bool gameStarted {get; private set;}
    public  bool gamePaused {get; private set;}
    public bool gameOver {get; private set;}
    public bool tutorialOpen {get; private set;}

    private void Awake()
    {
        gameStarted = false;
        gamePaused = false;
        gameOver = false;
        ShowTutorial();
    }

    private void Update()
    {
        bool pressedEsc = Input.GetKeyDown(KeyCode.Escape);
        if (pressedEsc && !gamePaused && !tutorialOpen && !gameOver)
            PauseGame();
        else if (pressedEsc && gamePaused && !tutorialOpen && !gameOver)
        {
            UnPauseGame();
        }
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

        if (blueSideScore == scoreLimit)
            GameOver();
        else
            ResetGame();
    }

    public void RedSideScored()
    {
        redSideScore++;
        redScored?.Invoke(redSideScore);

        if (redSideScore == scoreLimit)
            GameOver();
        else
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

    private void GameOver()
    {
        gameOverMenu.Show();
        gameOver = true;
        Time.timeScale = 0f;
    }

    private void PauseGame()
    {
        pauseMenu.Show();
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        pauseMenu.Close();
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void ShowTutorial()
    {
        tutorialOpen = true;
        tutorial.Show();
        Time.timeScale = 0f;

        if (gamePaused)
            pauseMenu.DisableButtons();

        if (gameOver)
            gameOverMenu.DisableButtons();
    }

    public void CloseTutorial()
    {
        tutorialOpen = false;
        tutorial.Close();
        pauseMenu.EnableButtons();
        gameOverMenu.EnableButtons();

        if (!gamePaused && !gameOver)
            Time.timeScale = 1f;
    }
}