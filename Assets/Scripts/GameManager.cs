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
        
    }

    private void Start()
    {
        playerData?.missileHandler.AddMissile(Resources.Load<BaseMissile>("Data/ScriptableObject/Missile/Missle1000"));
        if (camera != null)
        {
            camera.Follow = playerData.transform;
            camera.LookAt = playerData.transform;
        }
        UIManager.Instance.OpenUI<BattlePanel>(UIConst._BattlePanel);
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
                Debug.LogWarning("×´Ì¬²»´æÔÚ");
                break;
        }
    }

    public void PlayerDied()
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
