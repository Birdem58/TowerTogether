using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisions : MonoBehaviour
{
    public KacanKovalayanSetter kacanKovalayanSetter;
    public Timer timer;
    public GameObject otherPlayer;
    public Collider2D dusmeCollider;
    public Collider2D dusmeCollider2;

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
        //E�er ka�anla collide edersek ve bu ka�an turuncu kedi olursa
        if (collision.gameObject.CompareTag("playa") && kacanKovalayanSetter.kacan == otherPlayer.tag)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.GriKazandi);
            dusmeCollider.isTrigger = true;
            dusmeCollider2.isTrigger = true;
        }
        //E�er Kovalayanla collide edersek ve bu kovalayan turuncu kedi olursa
       else if (collision.gameObject.CompareTag("playa") && kacanKovalayanSetter.kovalayan == otherPlayer.tag)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.GriKaybetti);
            dusmeCollider.isTrigger = true;
            dusmeCollider2.isTrigger = true;
        }
    }

}
