using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    
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
            if(isGameOnPause)
            {
                Devam();
            }
            else
            {
                Dur();
            }
        }
    }

  public  void Devam()
    {
        isGameOnPause = false;
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }
   public  void Dur()
    {
        isGameOnPause = true;
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
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
