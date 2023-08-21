using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KacanKovalayanSetter : MonoBehaviour
{

    public string kacan;
    public string kovalayan;
    public string p1 = "playa";
    public string p2 = "playanumba2";
    public Transform kacanTriangle;
    public Transform kovalayanTriangle;
    public Transform player1;
    public Transform player2;
    public GameObject canvas;
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
        canvas.SetActive(state == GameManager.GameState.SelectKedy);
    }

    // Start is called before the first frame update
    void Start()
    {
        kacanTriangle.transform.position = new Vector3(100, 100, 100);
        kovalayanTriangle.transform.position = new Vector3(100, 100, 100);
        
    }

    // Update is called once per frame
    void Update()
    {
       if(kacan == p2 && kovalayan == p1)
        {
            kacanTriangle.transform.position = player2.position + new Vector3(0, 0.5f, 0);
            kovalayanTriangle.transform.position = player1.position + new Vector3(0, 0.5f, 0);
        }
       else if(kacan == p1 && kovalayan == p2)
        {
            kacanTriangle.transform.position = player1.position + new Vector3(0, 0.5f, 0);
            kovalayanTriangle.transform.position = player2.position + new Vector3(0, 0.5f, 0);
        }
    }

    public void KacanGri()
    {
        kacan = p2;
        kovalayan = p1;

        GameManager.Instance.UpdateGameState(GameManager.GameState.GriKovaliyor);
    }

    public void KovalayanGri()
    {
        kacan = p1;
        kovalayan = p2;
        GameManager.Instance.UpdateGameState(GameManager.GameState.GriKaciyor);

    }
}
