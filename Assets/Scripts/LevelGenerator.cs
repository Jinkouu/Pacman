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

    private int[,] mirrorVertically(int[,] levelMap)
    {
        int rows = levelMap.GetLength(0);
        int cols = levelMap.GetLength(1);

        int[,] temp = new int[rows, cols];


        for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                temp[i, j] = levelMap[rows - 1 - i, j];
            }
        }
        return temp;
    }

    private int[,] mirrorHorizontally(int[,] levelMap)
    {
        int rows = levelMap.GetLength(0);
        int cols = levelMap.GetLength(1);

        int[,] temp = new int[rows, cols];


        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                temp[i, j] = levelMap[i, cols - 1 - j];
            }
        }
        return temp;
    }

    private int[,] mirrorHoriAndVert(int[,] levelMap)
    {
        int rows = levelMap.GetLength(0);
        int cols = levelMap.GetLength(1);

        int[,] temp = new int[rows, cols];


        for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                temp[i, j] = levelMap[rows - 1 - i, cols - 1 - j];
            }
        }
        return temp;
    }

    [SerializeField] private GameObject sprite1;
    [SerializeField] private GameObject sprite2;
    [SerializeField] private GameObject sprite3;
    [SerializeField] private GameObject sprite4;
    [SerializeField] private GameObject sprite5;
    [SerializeField] private GameObject sprite6;
    [SerializeField] private GameObject sprite7;

    private int startX = 0;
    private int startY = 0;
    //private int startX = 0;
    //private int startY = 0;

    // Start is called before the first frame update
    void Start()
    {
        generate(levelMap);
        startX += levelMap.GetLength(1);
        generate(mirrorHorizontally(levelMap));
        startY -= levelMap.GetLength(0)-1;
        generate(mirrorHoriAndVert(levelMap));
        startX = 0;
        generate(mirrorVertically(levelMap));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generate(int[,] levelMap)
    {
        for (int x = 0; x < levelMap.GetLength(1); x++)        //y location
        {
            for (int y = 0; y < levelMap.GetLength(0); y++)    //x location
            {
                switch (levelMap[y,x])
                {
                    case 0: //do nothing
                        break;
                    case 1:
                        Instantiate(sprite1, new Vector3(startX + x, startY - y, 0), Quaternion.identity);
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
