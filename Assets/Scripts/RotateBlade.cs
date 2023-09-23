using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlade : MonoBehaviour
{
    private Transform transform;
    private float timee;
    public float rotateAngle = 15.0f;
    public float rotationPerSecond = 0.5f;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

     
    void Update()
    {
        timee += Time.deltaTime;
        if(timee >= rotationPerSecond)
        { transform.Rotate(0, 0, rotateAngle);
            timee = 0;
        }
        
    }
}
