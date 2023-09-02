using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MenuManager : MonoBehaviour
    {
        public GameObject menuCanvas;

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
        menuCanvas.SetActive(state == GameManager.GameState.MenuManager);
    }
    
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OpenMenu()
        {
            menuCanvas.SetActive(true);
        }

         public void CloseMenu()
          {
        menuCanvas.SetActive(false);
           }

     public void OnOynaClick()
     {
        GameManager.Instance.UpdateGameState(GameManager.GameState.MapSecim);
     }

     public void OnCıkClick()
      {
        Application.Quit();
      }


    }
