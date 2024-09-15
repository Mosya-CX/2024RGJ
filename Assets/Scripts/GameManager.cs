using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        switch (currentState)
        {
            case GameStates.GamePlay:
                timer += Time.deltaTime;
                CheckForPauseAndResume();
                break;

            case GameStates.Paused:
                CheckForPauseAndResume();
                break;

            case GameStates.Gameover:
                break;

            default:
                Debug.LogWarning("״̬������");
                break;
        }
    }

    public void PauseGame()
    {
        if(currentState != GameStates.Paused)
        {
            previousState = currentState;
            currentState = GameStates.Paused;
            Time.timeScale = 0f;//��ͣ��Ϸ
            Debug.Log("��Ϸ��ͣ");
        }
    }

    public void ResumeGame()
    {
        if(currentState == GameStates.Paused)
        {
            currentState = previousState;
            Time.timeScale = 1.0f;
            Debug.Log("��Ϸ����");
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
