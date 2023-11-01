using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;

public class Ghost : MonoBehaviour
{
    public GameObject ghost;
    public int currentX;
    public int currentY;
    public float startX;
    public float startY;
    public Vector3 start;
    public int lastInput;
    public int currentInput;

    public bool isScared = false;
    public bool isRecovery = false;
    public bool isNormal = false;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        start = ghost.transform.position;
        startX = currentX; 
        startY = currentY;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getStartX()
    {
        return startX;
    }

    public float getStartY()
    {
        return startY;
    }
}
