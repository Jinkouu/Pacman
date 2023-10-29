using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timer = 10f;
    private Text timerText;
    private GhostController animator;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            timerText = GetComponent<Text>();
            GameObject animatorObj = GameObject.FindGameObjectWithTag("GhostController"); 
            animator = animatorObj.GetComponent<GhostController>();
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void countdown()
    {
        if (!animator.isScared)
        {
            animator.scaredState();
        }
        StartCoroutine(actualTimer());
    }

    IEnumerator actualTimer()
    {
        while (timer > 0)
        {
            if(timer <= 3)
            {
                if (!animator.isRecovery)
                {
                    animator.recoveryState();
                }
            }

            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        //timer is at 0
        timerText.text = "";
        if (!animator.isNormal)
        {
            animator.normalState();
        }
    }
}
