using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{

    public Tween(Transform transform, Vector3 startPos, Vector3 endPos, float startTime, float duration)
    {
        this.Target = transform;
        StartPos = startPos;
        EndPos = endPos;
        StartTime = startTime;
        Duration = duration;
    }

    public Transform Target
    {
        get;
        private set;
    }

    public Vector3 StartPos
    {
        get;
        private set;
    }

    public Vector3 EndPos
    {
        get;
        private set;
    }

    public float StartTime
    {
        get;
        private set;
    }

    public float Duration
    {
        get;
        private set;
    }
}
