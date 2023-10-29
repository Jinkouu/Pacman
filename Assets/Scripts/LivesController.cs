using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    public Image[] lives;
    private int livesCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceLife()
    {
        if(livesCount > 0) 
        {
            livesCount--;
            lives[livesCount].gameObject.SetActive(false);
        }
    }

}
