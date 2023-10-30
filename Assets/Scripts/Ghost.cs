using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject ghost;
    public int currentX;
    public int currentY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int getX()
    {
        return currentX;
    }

    private int getY()
    {
        return currentY;
    }
}
