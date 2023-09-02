using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float sure = 1;
    public float bitis = 1;
    public float baslangýc = 0;
    public float hýz = 0.1f;
    public SpriteRenderer blokSprite;
    private Collider2D colliderýmýz;
    Color blokRenk;
    Color normal = Color.white;
    Color transparant;
    Color lerpedColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        colliderýmýz = GetComponent<BoxCollider2D>();
        blokRenk = blokSprite.color;
        transparant = Color.white;
        transparant.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        blokSprite.color = blokRenk;

    }

    private void MakeFade()
    {

       lerpedColor = Color.Lerp(normal, transparant, Mathf.MoveTowards(baslangýc, bitis, hýz));
       blokRenk = lerpedColor;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MakeFade();
       Invoke(nameof(CollisionKapa),sure);
    }

    private void CollisionKapa()
    {   
        
        colliderýmýz.isTrigger = true;
        Invoke(nameof(CollisionAc), sure);
    }


    private void CollisionAc()
    {

        colliderýmýz.isTrigger = false;
    }
}
