using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallColission : MonoBehaviour
{
    public KacanKovalayanSetter kacanKovalayanSetter;
    public MapManager mapManager;
    public int mapIndex;
    public GameObject otherPlayer;
    
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if(mapManager.currentMap == mapManager.maps[mapIndex])
        {
            if (collision.gameObject.CompareTag("playa"))
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.GriKazandi);
                
            }
            else
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.GriKaybetti);
                
            }
        }
       
    }
}
