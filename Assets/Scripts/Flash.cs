using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private bool setCondution = true;
   
    public float numSecond;
    public bool stateChecker;
    public GameObject flashCanvas;
    public MapManager mapManager;
  
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {




        if (stateChecker)
        {
            flashCanvas.SetActive(false);
        }
        else if (mapManager.currentMap == mapManager.maps[1] && setCondution)
            {
            setCondution = false;
            StartCoroutine(Flesh(numSecond));
            }


    }

    public IEnumerator Flesh(float numSecond)
    {

        flashCanvas.SetActive(false);
        yield return new WaitForSeconds(numSecond);
        StartCoroutine(Black(numSecond));

    }


    public IEnumerator Black(float numSecond)
    {
        flashCanvas.SetActive(true);
        yield return new WaitForSeconds(numSecond);
        StartCoroutine(Flesh(numSecond));
    }
}
