using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        convertLevel(levelMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    private int[,] newLevelMap;

    public int[,] getLevel()
    {
        convertLevel(levelMap);
        return newLevelMap;
    }

    private void convertLevel(int[,] levelMap)
    {
        int rows = levelMap.GetLength(0);
        int cols = levelMap.GetLength(1);

        int newRows = 2 * rows;
        int newCols = 2 * cols;

        newLevelMap = new int[newRows, newCols];
        //top left
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                newLevelMap[y, x] = levelMap[y, x];
            }
        }
        //top right
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                newLevelMap[y, newCols - 1 - x] = levelMap[y, x];
            }
        }
        //bottom left
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                newLevelMap[newRows - 2 - y, x] = levelMap[y, x];
            }
        }
        //bottom right
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                newLevelMap[newRows - 2 - y, newCols - 1 - x] = levelMap[y, x];
            }
        }
    }
}
