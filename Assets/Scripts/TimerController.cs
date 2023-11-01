using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timer = 10f;
    private Text timerText;
    private GhostController ghost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void countdown()
    {
        timer = 10f;
        StartCoroutine(actualTimer());
    }

    IEnumerator actualTimer()
    {
        timerText = GetComponent<Text>();
        GameObject ghostObj = GameObject.FindGameObjectWithTag("GhostController");
        ghost = ghostObj.GetComponent<GhostController>();
        ghost.scaredState();

        while (timer > 0)
        {
            if(timer <= 3)
            {
                if(ghost.isRecovery != true)
                {
                    ghost.recoveryState();
                }
            }

            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        //ghost.resetAnimation();
        //timer is at 0
        timerText.text = "";
        ghost.startMoving();
    }
}
