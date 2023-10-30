using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerController : MonoBehaviour
{
    public Text timer;
    private float startTime;
    private float currTime;
    private float pausedTime;
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
        startTime = Time.time - pausedTime;

        while (isActive)
        {
            currTime = Time.time - startTime;
            timer.text = convertTime(currTime);
            yield return null;
        }
        pausedTime = currTime;
    }

    public string convertTime(float currentTime)
    {
        string mins = ((int)(currentTime / 60)).ToString("D2");
        string secs = ((int)(currentTime % 60)).ToString("D2");
        string ms = ((int)((currentTime * 100) % 100)).ToString("D2");
        return mins + ":" + secs + ":" + ms;
    }

    public float getTime()
    {
        return currTime;
    }

    public void stopTimer()
    {
        isActive = false;
    }

}
