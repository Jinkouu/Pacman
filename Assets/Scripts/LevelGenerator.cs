using System;
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

    [SerializeField] private GameObject sprite1;
    [SerializeField] private GameObject sprite2;
    [SerializeField] private GameObject sprite3;
    [SerializeField] private GameObject sprite4;
    [SerializeField] private GameObject sprite5;
    [SerializeField] private GameObject sprite6;
    [SerializeField] private GameObject sprite7;

    //private int startX = -10;
    //private int startY = 13;
    private int startX = 0;
    private int startY = 0;

    // Start is called before the first frame update
    void Start()
    {
        generate(levelMap);
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
                switch (levelMap[i,j])
                {
                    case 0: //do nothing
                        break;
                    case 1:
                        Instantiate(sprite1, new Vector3(startX + j, startY - i, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(sprite2, new Vector3(startX + j, startY - i, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(sprite3, new Vector3(startX + j, startY - i, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(sprite4, new Vector3(startX + j, startY - i, 0), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(sprite5, new Vector3(startX + j, startY - i, 0), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(sprite6, new Vector3(startX + j, startY - i, 0), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(sprite7, new Vector3(startX + j, startY - i, 0), Quaternion.identity);
                        break;

                }
            }
        }
    }

}
