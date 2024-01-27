using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameWinUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] FloatVariable health;

    [SerializeField] GameObject respawn;

    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] VoidEvent gameOverEvent;
    [SerializeField] GameObjectEvent respawnEvent;

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
    public int lives = 0;

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            timerUI.text = string.Format("{0:F1}", timer);
        }
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            livesUI.text = "Lives: " + lives.ToString();
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
                gameOverUI.SetActive(false);
                gameWinUI.SetActive(false);
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                gameWinUI.SetActive(false);
                gameOverUI.SetActive(false);
                timer = 60;
                Lives = 3;
                health.value = 100;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0)
                {
                    state = State.DEATH;
                }
                break;
            case State.DEATH:
                Lives--;
                if (Lives == 0)
                {
                    state = State.GAME_OVER;
                }
                else
                {
                    timer = 60;
                    health.value = 100;
                    state = State.PLAY_GAME;
                    gameStartEvent.RaiseEvent();
                    respawnEvent.RaiseEvent(respawn);
                }
                break;
            case State.GAME_OVER:
                gameOverEvent.RaiseEvent();
                gameOverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.GAME_WIN:
				gameOverEvent.RaiseEvent();
				gameWinUI.SetActive(true);
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
        if(points >= 1000)
        {
            state = State.GAME_WIN;
        }
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}