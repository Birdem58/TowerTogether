using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float timerStart = 60f;
    public float timerCounter;
    public bool gameOnPause = false;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = timerCounter.ToString("0");
        CheckPause();
        timerCounter -= Time.deltaTime;
    }

    public void CheckPause()
    {
        if(gameOnPause)
        {
            timerCounter = timerStart;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void SetTimer()
    {
        timerCounter = timerStart;
    }
}
