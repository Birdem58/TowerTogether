using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisions : MonoBehaviour
{
    public KacanKovalayanSetter kacanKovalayanSetter;
    public GameObject otherPlayer;
    private string otherPlayerTag;

    // Start is called before the first frame update
    void Start()
    { 
        otherPlayerTag = otherPlayer.tag;
        Debug.Log(otherPlayerTag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Eðer kaçanla collide edersek ve bu kaçan turuncu kedi olursa
        if (collision.gameObject.CompareTag("playa") && kacanKovalayanSetter.kacan == otherPlayerTag)
        {
            Debug.Log("KAZANDIIN");
        }
        //Eðer Kovalayanla collide edersek ve bu kovalayan turuncu kedi olursa
       else if (collision.gameObject.CompareTag("playa") && kacanKovalayanSetter.kovalayan == otherPlayerTag)
        {
            Debug.Log("Kaybettin");
        }
    }

}
