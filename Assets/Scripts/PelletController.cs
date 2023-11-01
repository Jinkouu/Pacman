using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{

    private int pelletCount = 0;
    private int[,] newLevelMap;

    // Start is called before the first frame update
    void Start()
    {
        //try
        //{
            GameObject levelObj = GameObject.FindGameObjectWithTag("LevelMap");
            LevelMap controller = levelObj.GetComponent<LevelMap>();
            newLevelMap = controller.getLevel();
            calcPelletAmount();
        //}
        //catch { }
    }

    public void calcPelletAmount()
    {
        int rows = newLevelMap.GetLength(0);
        int cols = newLevelMap.GetLength(1);

        for (int y = 0; y < rows; y++)
        {
            for(int x = 0;  x < cols; x++)
            {
                if (newLevelMap[y, x] == 5)
                {
                    pelletCount++;
                }
            }
        }
        //Debug.Log(pelletCount);
    }

    public void reducePellet()
    {
        pelletCount--;
    }

    public int getPelletCount()
    {
        return pelletCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
