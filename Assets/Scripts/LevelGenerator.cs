using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] levelMap =
            {
                {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
                {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
                {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
                {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
                {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
                {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
                {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
                {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
                {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
                {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
                {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
                {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
                {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
                {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
                {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
            };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generate(int[,] levelMap)
    {
        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                switch(levelMap[i,j])
                {
                    case 0: //do nothing
                        break;

                }
            }
        }
    }

}
