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

    private int startX = -10;
    private int startY = 13;
    //private int startX = 0;
    //private int startY = 0;

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
        for (int x = 0; x < levelMap.GetLength(0); x++)        //y location
        {
            for (int y = 0; y < levelMap.GetLength(1); y++)    //x location
            {
                Debug.Log(levelMap[y, x]);
                switch (levelMap[y,x])
                {
                    case 0: //do nothing
                        break;
                    case 1:
                        //case 1, wall2 on right and bottom
                        if (levelMap[y + 1, x] == 2 && levelMap[x + 1, y] == 2)
                        {
                            Instantiate(sprite1, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
                        }
                        //case 2, wall2 on right and top
                        else if (levelMap[y - 1, x] == 2 && levelMap[y, x + 1] == 2)
                        {
                            Instantiate(sprite1, new Vector3(startX + x, startY - y, 0), Quaternion.Euler(0f, 0f, 90f));
                        }
                        //case 3, wall2 on bottom and left
                        else if (levelMap[y, x-1] == 2 && levelMap[y+1, x] == 2)
                        {
                            Instantiate(sprite1, new Vector3(startX + x, startY - y, 0), Quaternion.Euler(0f, 0f, 270f));
                        }
                        ///////case 4, wall2 on top and left
                        else if (levelMap[y-1, x] == 2 && levelMap[y, x-1] == 2)
                        {
                            Instantiate(sprite1, new Vector3(startX + x, startY - y, 0), Quaternion.Euler(0f, 0f, 180f));
                        }

                        break;
                    case 2:
                        Instantiate(sprite2, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(sprite3, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(sprite4, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(sprite5, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(sprite6, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(sprite7, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
                        break;

                }
            }
        }
    }

}
