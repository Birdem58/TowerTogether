using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public MapManager mapManager;
    public GameObject kacanLight;
    public GameObject kovalayanLight;
    public GameObject arcLight;
    

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mapManager.currentMap == mapManager.maps[1] )
        {
            kacanLight.SetActive(true);
            kovalayanLight.SetActive(true);
            arcLight.SetActive(true);
        }
        else
        {
            kacanLight.SetActive(false);
            kovalayanLight.SetActive(false);
            arcLight.SetActive(false);
        }
    }
}
