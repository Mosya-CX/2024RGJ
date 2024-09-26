using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public enum GameStates
{
    GamePlay,
    Paused,
    Gameover
}
public class GameManager : SingletonWithMono<GameManager>
{
    public GameStates currentState;
    public GameStates previousState;

    public PlayerMovement playerData;
    public float timer;
    public CinemachineVirtualCamera camera;
    public float GeneMutationSpace = 10f;
    public float selectSpace = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        UIManager.Instance.Init();
        AudioManager.Instance.Init();
        GeneMutationManager.Instance.Init();
        timer = 0;
        PauseGame();

        playerData.gameObject.SetActive(false);
        EnemyManager.Instance.gameObject.SetActive(false);
        UIManager.Instance.OpenUI<MainPanel>(UIConst._MainPanel);
        AudioManager.Instance.PlayBGM("主界面BGM");
    }

    private void Start()
    {
        
        if (camera != null)
        {
            camera.Follow = playerData.transform;
            camera.LookAt = playerData.transform;
        }
        //UIManager.Instance.OpenUI<BattlePanel>(UIConst._BattlePanel);
    }
    void Update()
    {

        switch (currentState)
        {
            case GameStates.GamePlay:
                CheckForPauseAndResume();
                timer += Time.deltaTime;
                if (timer > GeneMutationSpace && timer % GeneMutationSpace < 0.01f && selectSpace <= 0)
                {
                    GeneMutationManager.Instance.MutateGenes();
                    selectSpace = 0.5f;
                }
                if (selectSpace > 0)
                {
                    selectSpace -= Time.deltaTime;
                }


                break;

            case GameStates.Paused:
                CheckForPauseAndResume();
                break;

            case GameStates.Gameover:
                break;

            default:
                Debug.LogWarning("状态不存在");
                break;
        }
    }

    public void PlayerDied()
    {
        currentState = GameStates.Gameover;
        Time.timeScale = 0f;
        UIManager.Instance.OpenUI<DeadPanel>(UIConst._DeadPanel);
        Debug.Log("游戏结束");
    }


    public void PauseGame()
    {
        if(currentState != GameStates.Paused)
        {
            previousState = currentState;
            currentState = GameStates.Paused;
            Time.timeScale = 0f;//暂停游戏
            Debug.Log("游戏暂停");
        }
    }

    public void ResumeGame()
    {
        if(currentState == GameStates.Paused)
        {
            currentState = previousState;
            Time.timeScale = 1.0f;
            Debug.Log("游戏继续");
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
