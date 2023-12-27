using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Timer timer;
    public PlayerColisions playerColisions;
    public MenuManager menuManager;
    public MapManager mapManager;
    public PauseManager pauseManager;
    
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
        UpdateGameState(GameState.MenuManager);
       
        
    }


    public void UpdateGameState(GameState newState)
    {
        State = newState;


        switch (newState)
        {
            case GameState.MenuManager:
                HandleMenuManager();
                break;
            case GameState.MapSecim:
                HandleMapSecim();
                break;
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
    private void HandleMenuManager()
    {
        menuManager.OpenMenu();
        timer.gameOnPause = true;
        
    }

    private void SetAllCanvasFalse()
    {
        canvasWin.SetActive(false);
        canvasLose.SetActive(false);
        playerColisions.dusmeCollider.isTrigger = false;
        playerColisions.dusmeCollider2.isTrigger = false;
    }
    private void HandleMapSecim()
    {
        mapManager.OpenMapMenu();
        pauseManager.pauseCanvas.SetActive(false);
        

    }

    public void HandleGameReset()
    {  
        UpdateGameState(GameState.MapSecim);
        SetAllCanvasFalse();
    }
    private void HandleGriKazandi()
    {
        canvasWin.SetActive(true);
      
        timer.gameOnPause = true;
       

    }

    private void HandleGriKaybetti()
    {
        canvasLose.SetActive(true);
        
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
        MenuManager,
        MapSecim,
        SelectKedy,
        GriKovaliyor,
        GriKaciyor,
        GriKazandi,
        GriKaybetti,


    }

}
