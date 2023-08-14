using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yippie : MonoBehaviour
{
    public AudioSource wee;
    public AudioClip yippie;
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wee.PlayOneShot(yippie);
        if (collision.otherCollider.CompareTag("playa")||collision.otherCollider.CompareTag("playanumba2"))
        {
            Debug.Log("playas collide");
          
        }
    }
}
