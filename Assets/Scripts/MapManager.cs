using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
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
        mapCanvas.SetActive(state == GameManager.GameState.MapSecim);
    }
    [SerializeField] new Transform camera;
    public Transform gri;
    public Transform turuncu;
    public Transform map1;
    public Transform map2;
    public Transform map3;
    public Transform m1GPos;
    public Transform m1TPos;
    public Transform m2GPos;
    public Transform m2TPos;
    public Transform m3GPos;
    public Transform m3TPos;
    [SerializeField] GameObject mapCanvas;
    public string[] maps = {"map1","map2" ,"map3"};
    public string currentMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMapMenu()
    {
        mapCanvas.SetActive(true);
    }
    public void OnClickMap1()
    {
        camera.transform.position = map1.transform.position;
        gri.transform.position = m1GPos.transform.position;
        turuncu.transform.position = m1TPos.transform.position;
        currentMap = maps[0];
        GameManager.Instance.UpdateGameState(GameManager.GameState.SelectKedy);
    }
    public void OnClickMap2()
    {
        camera.transform.position = map2.transform.position;
        gri.transform.position = m2GPos.transform.position;
        turuncu.transform.position = m2TPos.transform.position;
        currentMap = maps[1];
        GameManager.Instance.UpdateGameState(GameManager.GameState.SelectKedy);
    }

    public void OnClickMap3()
    {
        camera.transform.position = map3.transform.position;
        gri.transform.position = m3GPos.transform.position;
        turuncu.transform.position = m3TPos.transform.position;
        currentMap = maps[2];
        GameManager.Instance.UpdateGameState(GameManager.GameState.SelectKedy);
    }
}
