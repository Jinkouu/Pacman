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
    private float startX;
    private float startY;
    public Vector3 start;
    public int lastInput;
    public int currentInput;
    // Start is called before the first frame update
    void Start()
    {
        start = ghost.transform.position;
        startX = ghost.transform.position.x; 
        startY = ghost.transform.position.y;
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
