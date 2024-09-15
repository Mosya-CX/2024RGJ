using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    public enum GameStates
    {
         GamePlay,
         Paused,
         Gameover
    }

    public GameStates currentState;
    public GameStates previousState;

    public PlayerMovement playerData;
    public float timer;

    protected override void Awake()
    {
        base.Awake();
        UIManager.Instance.Init();
        AudioManager.Instance.Init();
        timer = 0;
        
    }

    private void Start()
    {
        playerData?.missileHandler.AddMissile(Resources.Load<BaseMissile>("Data/ScriptableObject/Missile/Missle1000"));
    }
    void Update()
    {

        switch (currentState)
        {
            case GameStates.GamePlay:
                CheckForPauseAndResume();
                timer += Time.deltaTime;
                break;

            case GameStates.Paused:
                CheckForPauseAndResume();
                break;

            case GameStates.Gameover:
                break;

            default:
                Debug.LogWarning("×´Ì¬²»´æÔÚ");
                break;
        }
    }

    public static void PlayerDied()
    {
        Application.Quit();
    }


    public void PauseGame()
    {
        if(currentState != GameStates.Paused)
        {
            previousState = currentState;
            currentState = GameStates.Paused;
            Time.timeScale = 0f;//ÔÝÍ£ÓÎÏ·
            Debug.Log("ÓÎÏ·ÔÝÍ£");
        }
    }

    public void ResumeGame()
    {
        if(currentState == GameStates.Paused)
        {
            currentState = previousState;
            Time.timeScale = 1.0f;
            Debug.Log("ÓÎÏ·¼ÌÐø");
        }
    }

    void CheckForPauseAndResume()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameStates.Paused)
                ResumeGame();
            else
                PauseGame();
        }
    }
}
