using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float sure = 1;
    public float bitis = 1;
    public float baslang�c = 0;
    public float h�z = 0.1f;
    public SpriteRenderer blokSprite;
    private Collider2D collider�m�z;
    Color blokRenk;
    Color normal = Color.white;
    Color transparant;
    Color lerpedColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        collider�m�z = GetComponent<BoxCollider2D>();
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

       lerpedColor = Color.Lerp(normal, transparant, Mathf.MoveTowards(baslang�c, bitis, h�z));
       blokRenk = lerpedColor;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MakeFade();
       Invoke(nameof(CollisionKapa),sure);
    }

    private void CollisionKapa()
    {   
        
        collider�m�z.isTrigger = true;
        Invoke(nameof(CollisionAc), sure);
    }


    private void CollisionAc()
    {

        collider�m�z.isTrigger = false;
    }
}
