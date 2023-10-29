using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerController : MonoBehaviour
{
    public Text timer;
    private float startTime;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTimer()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        isActive = true;
        startTime = Time.time;

        while (isActive)
        {
            float currentTime = Time.time - startTime;
            string mins = ((int)(currentTime / 60)).ToString("D2");
            string secs = ((int)(currentTime % 60)).ToString("D2");
            string ms = ((int)((currentTime * 100) % 100)).ToString("D2");
            timer.text = mins + ":" + secs + ":" + ms;
            yield return null;
        }
    }

    public void stopTimer()
    {
        isActive = false;
    }
}
