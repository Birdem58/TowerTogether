using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject sesCanvas;

    public Timer timer;

    public bool isGameOnPause { private set;  get; }
    private void Awake()
    {
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;
     
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
    }
    private void GameManager_OnGameStateChange(GameManager.GameState state)
    {
       

    }

    private void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
          {
            Dur();          
        }


        if(isGameOnPause)
        {
            timer.timerCounter = timer.timeranlýk;
        }
        
    }
    public void SesAyar()
    {
        sesCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        
        
    }
    
  public  void Devam()
    {
       
        isGameOnPause = false;
        pauseCanvas.SetActive(false);
    }
   public  void Dur()
    {
        Debug.Log("dur basýldý");
        

        sesCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
       isGameOnPause = true;
    }

    public void Cýk()
    {
        Application.Quit();
    }

   public void HaritaStateChange()
    {
        Time.timeScale = 0f;
        isGameOnPause = false;
        pauseCanvas.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.MapSecim);
    }
}
