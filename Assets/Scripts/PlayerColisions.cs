using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisions : MonoBehaviour
{
    public KacanKovalayanSetter kacanKovalayanSetter;
    public Timer timer;
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
    private void Update()
    {
        if(timer.timerCounter <= 0)
        {
            if(kacanKovalayanSetter.kacan == otherPlayer.tag)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.GriKaybetti);
            }
            else
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.GriKazandi);
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Eðer kaçanla collide edersek ve bu kaçan turuncu kedi olursa
        if (collision.gameObject.CompareTag("playa") && kacanKovalayanSetter.kacan == otherPlayer.tag)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.GriKazandi);
        }
        //Eðer Kovalayanla collide edersek ve bu kovalayan turuncu kedi olursa
       else if (collision.gameObject.CompareTag("playa") && kacanKovalayanSetter.kovalayan == otherPlayer.tag)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.GriKaybetti);
        }
    }

}
