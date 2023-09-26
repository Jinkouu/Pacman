using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;
    //private List<Tween> activeTweens = new List<Tween>();
    private float startTime;
    private float journeyLength;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
        {
            //float distCovered = (Time.time - startTime) * 1.0f;
            float distCovered = (timer - activeTween.StartTime) * 1.0f;
            journeyLength = Vector3.Distance(activeTween.StartPos, activeTween.EndPos);
            var t = distCovered / activeTween.Duration;
            activeTween.Target.transform.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, t);
        }
        if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) <= 0.1f)
        {
            activeTween.Target.transform.position = activeTween.EndPos;
            activeTween = null;
        }


    }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            startTime = timer;
        }
    }
}
