using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Timer timer;
    public UIanim griAnim;
    public UIanim turuncuAnim;
    public GameState State;
    public GameObject canvasWin;
    public GameObject canvasLose;
    public static event Action<GameState> OnGameStateChange;
    private void Awake()
    {
        Instance = this;
        canvasLose.SetActive(false);
        canvasWin.SetActive(false);
    }
    private void Start()
    {
        UpdateGameState(GameState.SelectKedy);
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;


        switch (newState)
        {
            case GameState.SelectKedy:
                HandleSelectKedy();
                break;
            case GameState.GriKovaliyor:
                HandleGriKovaliyor();
                break;
            case GameState.GriKaciyor:
                HandleGriKaciyor();
                break;
            case GameState.GriKaybetti:
                HandleGriKaybetti();
                break;
            case GameState.GriKazandi:
                HandleGriKazandi();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState),newState, null);

                
        }
        OnGameStateChange?.Invoke(newState);
    }

    public void HandleGameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void HandleGriKazandi()
    {
        canvasWin.SetActive(true);
        griAnim.Func_PlayUIAnim();
        timer.gameOnPause = true;
        
    }

    private void HandleGriKaybetti()
    {
        canvasLose.SetActive(true);
        turuncuAnim.Func_PlayUIAnim();
        timer.gameOnPause = true;

    }

    private void HandleGriKaciyor()
    {
        timer.SetTimer();

        timer.gameOnPause = false;

    }

    private void HandleGriKovaliyor()
    {
       
        timer.SetTimer();
        timer.gameOnPause = false;

    }

    private void HandleSelectKedy()
    {
        timer.gameOnPause = true;
    }
    public enum GameState
    {
        SelectKedy,
        GriKovaliyor,
        GriKaciyor,
        GriKazandi,
        GriKaybetti,


    }

}
