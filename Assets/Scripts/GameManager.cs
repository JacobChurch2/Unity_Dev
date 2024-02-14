using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject? gameOverUI;
    [SerializeField] GameObject? gameWinUI;
    [SerializeField] TMP_Text? livesUI;
    [SerializeField] TMP_Text? timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;

    [SerializeField] GameObject? respawn;

    [SerializeField] PathFollower playerPath;
    [SerializeField] PlayerShip playerShip;
    [SerializeField] TMP_Text gameOverScoreText;

    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent? gameStartEvent;
    [SerializeField] VoidEvent? gameOverEvent;
    [SerializeField] GameObjectEvent? respawnEvent;

    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        DEATH,
        GAME_OVER,
        GAME_WIN
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 1;

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            if(timerUI) timerUI.text = string.Format("{0:F1}", timer);
        }
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            if(livesUI) livesUI.text = "Lives: " + lives.ToString();
        }
    }

    private void OnEnable()
    {
        //scoreEvent.Subscribe(OnAddPoints);
    }

    private void OnDisable()
    {
        //scoreEvent.Unsubscribe(OnAddPoints);
    }

    void Start()
    {

    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                if(gameOverUI) gameOverUI.SetActive(false);
                if(gameWinUI) gameWinUI.SetActive(false);
                titleUI.SetActive(true);
                playerPath.speed = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                if (gameWinUI) gameWinUI.SetActive(false);
                if (gameOverUI) gameOverUI.SetActive(false);
                //timer = 60;
                //Lives = 3;
                health.value = 100;
                playerPath.speed = 15;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                if(gameStartEvent) gameStartEvent.RaiseEvent();
                if (respawn && respawnEvent) respawnEvent.RaiseEvent(respawn);
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                //Timer = Timer - Time.deltaTime;
                //if (Timer <= 0)
                //{
                //    state = State.DEATH;
                //}
                if(playerShip.health.value <= 0 || playerPath.tdistance >= 1)
                {
                    state = State.DEATH; 
                }
                break;
            case State.DEATH:
                Lives--;
                if (Lives <= 0)
                {
                    state = State.GAME_OVER;
                }
                else
                {
                    timer = 60;
                    health.value = 100;
                    state = State.PLAY_GAME;
                    if (gameStartEvent) gameStartEvent.RaiseEvent();
                    if(respawn && respawnEvent) respawnEvent.RaiseEvent(respawn);
                }
                break;
            case State.GAME_OVER:
                if(gameOverEvent) gameOverEvent.RaiseEvent();
                if (gameOverUI) gameOverUI.SetActive(true);
                gameOverScoreText.text = "Game Over\nPoints: " + playerShip.score.value.ToString();
                playerPath.speed = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.GAME_WIN:
                if (gameOverEvent) gameOverEvent.RaiseEvent();
                if (gameWinUI) gameWinUI.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
        }

        healthUI.value = health.value / 100.0f;
    }

    public void OnPlayerDead()
    {
        state = State.DEATH;
    }

    public void IncreaseTime(float increase)
    {
        timer += increase;
    }

    public void OnStartGame()
    {
        state = State.START_GAME;
    }

    public void OnAddPoints(int points)
    {
        print(points);
        //if(points >= 1000)
        //{
        //    state = State.GAME_WIN;
        //}
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}