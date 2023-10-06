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
    //int[,] levelMap =
    //    {
    //      {1,2,2,2,2,2,2,1},
    //      {2,0,0,0,0,0,0,2},
    //      {2,0,0,3,3,0,0,2},
    //      {2,0,3,3,3,3,0,2},
    //      {2,0,4,0,3,3,0,2},
    //      {2,0,3,4,3,0,0,2},
    //      {2,0,0,0,0,0,0,2},
    //      {1,2,2,2,2,2,2,1},
    //    };
    //int[,] levelMap =
    //{
    //    {1,2,2,2,2,2,1,0,0,0,0,1,2,2,2,2,2},
    //    {2,5,5,5,5,5,1,2,2,2,2,1,5,5,5,5,5},
    //    {2,5,3,4,4,3,5,5,5,5,5,5,3,7,3,5,5},
    //    {2,6,4,0,0,4,5,3,4,4,3,5,4,7,7,5,5},
    //    {2,5,3,4,4,3,5,3,4,4,3,5,3,7,3,5,5},
    //    {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
    //    {7,3,6,3,4,3,5,3,3,5,3,4,4,4,4,4,4},
    //    {7,3,6,3,4,3,5,4,4,5,3,4,4,3,0,0,0},
    //    {2,5,5,5,5,5,5,4,4,5,5,5,5,4,0,0,0},
    //    {1,2,2,2,2,1,5,4,3,4,4,3,0,4,0,0,0},
    //    {0,0,0,0,0,2,5,4,3,4,4,3,0,3,4,4,4},
    //    {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0},
    //    {0,0,0,0,0,2,5,4,4,0,0,3,4,4,4,4,0},
    //    {0,0,0,0,0,2,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,1,2,2,2,1,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,2,0,0,0,0,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,2,0,0,0,0,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,2,0,0,0,0,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,1,1,0,0,0,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,0,1,1,0,0,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,0,0,2,0,0,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,0,0,1,2,1,5,4,4,0,0,4,0,0,0,0,0},
    //    {0,0,0,0,0,2,5,4,4,0,0,4,0,0,0,0,0},
    //    {2,2,2,2,2,1,5,3,3,0,3,3,0,0,0,0,0},
    //    {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0},
    //};

    private Transform[,] transArray;

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
    [SerializeField] private GameObject normalPellet;
    [SerializeField] private GameObject powerPellet;

    private int startX = 0;
    private int startY = 0;
    //private int startX = 0;
    //private int startY = 0;

    // Start is called before the first frame update
    void Start()
    {
        //top left
        transArray = new Transform[levelMap.GetLength(0), levelMap.GetLength(1)];
        generate(levelMap);
        rotate(transArray);
        //top right
        startX += levelMap.GetLength(1);
        transArray = new Transform[levelMap.GetLength(0), levelMap.GetLength(1)];
        generate(mirrorHorizontally(levelMap));
        rotate(transArray);
        //bottom right
        startY -= levelMap.GetLength(0) - 1;
        transArray = new Transform[levelMap.GetLength(0), levelMap.GetLength(1)];
        generate(mirrorHoriAndVert(levelMap));
        rotate(transArray);
        //bottom left
        startX = 0;
        transArray = new Transform[levelMap.GetLength(0), levelMap.GetLength(1)];
        generate(mirrorVertically(levelMap));
        rotate(transArray);
    }

    private void rotate(Transform[,] transArray)
    {
        rotateStraight(transArray);
        rotateEdges(transArray);
    }

    private void rotateStraight(Transform[,] transArray)
    {
        for (int x = 0; x < levelMap.GetLength(1); x++)        //y location
        {
            for (int y = 0; y < levelMap.GetLength(0); y++)    //x location
            {
                try
                {
                    //Debug.Log(transArray[y, x]);
                    switch (transArray[y, x].tag)
                    {
                        case "Wall 2":
                            if (transArray[y - 1, x].tag == "Wall 1" || transArray[y - 1, x].rotation.eulerAngles.z == 90f)
                            {
                                transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            }
                            else if (transArray[y + 1, x].tag == "Wall 1" || transArray[y + 1, x].tag == "Wall 2")
                            {
                                transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            }
                            break;
                       
                        case "Wall 4":
                            //on top is a edge piece that is going down
                            if (y == 1)
                            {
                                if (transArray[y + 1, x].tag == "Wall 3" || transArray[y + 1, x].tag == "Wall 4")
                                {
                                    transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                                }
                            }
                            else if (y == transArray.GetLength(0) - 1)
                            {
                                if ((transArray[y - 1, x].tag == "Wall 4" && transArray[y-1, x].rotation.eulerAngles.z == 90f) 
                                    || transArray[y - 1, x].tag == "Wall 3" && (transArray[y-1, x].rotation.eulerAngles.z == 0f || transArray[y - 1, x].rotation.eulerAngles.z == 270f))
                                {
                                    transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                                }
                            }
                            else if ((transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].rotation.eulerAngles.z == 90f))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            }
                            else if ((transArray[y - 1, x].tag == "Wall 3" || (transArray[y-1, x].tag == "Wall 4" && transArray[y-1, x].rotation.eulerAngles.z == 90f)) && (transArray[y + 1, x].tag == "Wall 3" || transArray[y+1, x]. tag == "Wall 4"))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            }
                            else if (transArray[y-1, x].tag == "Wall 7" || transArray[y+1, x].tag == "Wall 7")
                            {
                                transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            }
                            
                            //if (y == 1)
                            //
                            //   transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            //
                            //else
                            //
                            //   if (transArray[y - 1, x].tag == "Wall 3" && (transArray[y - 1, x].rotation.eulerAngles.z == 270f || transArray[y - 1, x].rotation.eulerAngles.z == 0f))
                            //   {
                            //       transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            //   }
                            //   else if (transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].rotation.eulerAngles.z == 90f)
                            //   {
                            //       transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            //   }
                            //   else if (transArray[y - 1, x].tag == "Wall 7")
                            //   {
                            //       transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            //   }
                            //
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    

                }
            }
        }
    }

    private void rotateEdges(Transform[,] transArray)
    {
        for (int x = 0; x < levelMap.GetLength(1); x++)        //y location
        {
            for (int y = 0; y < levelMap.GetLength(0); y++)    //x location
            {
                try
                {
                    //Debug.Log(transArray[y, x]);
                    switch (transArray[y, x].tag)
                    {
                        case "Wall 1":
                            //if (y > 0 && y < levelMap.GetLength(0)-1)
                            if ((transArray[y, x + 1].tag == "Wall 2" || (transArray[y, x + 1].tag == "Wall 1")) 
                                && (transArray[y - 1, x].tag == "Wall 2" || transArray[y - 1, x]. tag == "Wall 1" && (transArray[y-1, x].rotation.eulerAngles.z == 0f || transArray[y-1, x].rotation.eulerAngles.z == 270f)))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            }
                            else if ((transArray[y, x - 1].tag == "Wall 2" || transArray[y, x-1].tag == "Wall 1" && (transArray[y, x-1].rotation.eulerAngles.z == 0f || transArray[y, x-1].rotation.eulerAngles.z ==90f)) //up and left
                                && (transArray[y - 1, x].tag == "Wall 2" || transArray[y - 1, x].tag == "Wall 1" && (transArray[y-1 , x].rotation.eulerAngles.z == 0f || transArray[y-1, x].rotation.eulerAngles.z == 270f)))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                            }
                            else if ((transArray[y, x - 1].tag == "Wall 2" || transArray[y, x-1].tag == "Wall 1" && (transArray[y, x-1].rotation.eulerAngles.z == 0f || transArray[y, x - 1].rotation.eulerAngles.z == 90f)) 
                                && (transArray[y + 1, x].tag == "Wall 2" || transArray[y + 1, x].tag == "Wall 1")) //&& (transArray[y + 1, x].rotation.eulerAngles.z == 90f || transArray[y + 1, x].rotation.eulerAngles.z == 180f)))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                            }
                            break;
                        case "Wall 3": //do this after wall 4
                            if (((transArray[y-1, x].tag == "Wall 4" && transArray[y-1, x].rotation.eulerAngles.z == 90f) || transArray[y - 1, x].tag == "Wall 3" && (transArray[y-1, x].rotation.eulerAngles.z == 0f || transArray[y - 1, x].rotation.eulerAngles.z == 270f))
                                && ((transArray[y, x + 1].tag == "Wall 4" && transArray[y, x + 1].rotation.z == 0f) || transArray[y, x + 1].tag == "Wall 3"))
                            {
                                if ((transArray[y, x - 1].tag == "Wall 3" && (transArray[y, x - 1].rotation.eulerAngles.z == 0 || transArray[y, x - 1].rotation.eulerAngles.z == 90f)) || (transArray[y, x - 1].tag == "Wall 4" && transArray[y, x - 1].rotation.eulerAngles.z == 0f))
                                {
                                    transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                                }
                                else
                                {
                                    transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                                }
                            }
                            else if (((transArray[y-1, x].tag == "Wall 4" && transArray[y-1, x].rotation.eulerAngles.z == 90f) || transArray[y - 1, x].tag == "Wall 3" && (transArray[y - 1, x].rotation.eulerAngles.z == 0f || transArray[y - 1, x].rotation.eulerAngles.z == 270f))
                                && ((transArray[y, x-1].tag == "Wall 4" && transArray[y, x-1].rotation.z == 0f) || (transArray[y, x - 1].tag == "Wall 3" && (transArray[y, x-1].rotation.eulerAngles.z == 90f || transArray[y, x-1].rotation.eulerAngles.z == 0f))))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                            }
                            else if (((transArray[y + 1, x].tag == "Wall 4" && transArray[y + 1, x].rotation.eulerAngles.z == 90f) || transArray[y + 1, x].tag == "Wall 3")
                                && ((transArray[y, x - 1].tag == "Wall 4" && transArray[y, x - 1].rotation.eulerAngles.z == 0f) || transArray[y, x - 1].tag == "Wall 3" && (transArray[y, x - 1].rotation.eulerAngles.z == 90f || transArray[y, x - 1].rotation.eulerAngles.z == 0f)))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                            }
                            //------ wall 7
                            else if (((transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].rotation.eulerAngles.z == 90f) || transArray[y - 1, x].tag == "Wall 3" && (transArray[y - 1, x].rotation.eulerAngles.z == 0f || transArray[y - 1, x].rotation.eulerAngles.z == 270f))
                                && (transArray[y, x + 1].tag == "Wall 7"))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                            }
                            else if (((transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].rotation.eulerAngles.z == 90f) || transArray[y - 1, x].tag == "Wall 3" && (transArray[y - 1, x].rotation.eulerAngles.z == 0f || transArray[y - 1, x].rotation.eulerAngles.z == 270f))
                                && (transArray[y, x - 1].tag == "Wall 7"))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                            }
                            else if (((transArray[y + 1, x].tag == "Wall 4" && transArray[y + 1, x].rotation.eulerAngles.z == 90f) || transArray[y + 1, x].tag == "Wall 3")
                                && (transArray[y, x - 1].tag == "Wall 7"))
                            {
                                transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                            }
                            break;
                        case "Wall 5":
                            break;
                        case "Wall 6":
                            break;
                        case "Wall 7":
                            if (y > 0 && y < transArray.GetLength(0) - 1 && x < transArray.GetLength(1) - 1)
                            {
                                if (((transArray[y-1, x].tag == "Wall 2" && transArray[y-1, x].rotation.eulerAngles.z == 90f) || transArray[y-1, x].tag == "Wall 1" && (transArray[y-1, x].rotation.eulerAngles.z == 0 || transArray[y-1, x].rotation.eulerAngles.z == 270f))
                                    && (transArray[y, x+1].tag == "Wall 4" || transArray[y, x+1].tag == "Wall 3"))
                                {
                                    transArray[y, x].transform.localScale = new Vector3(-1, 1, 1);
                                    transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                                }
                                else if (((transArray[y+1, x].tag == "Wall 2" && transArray[y + 1, x].rotation.eulerAngles.z == 90f) || transArray[y+1, x].tag == "Wall 1")
                                    && (transArray[y, x+1].tag == "Wall 4" || transArray[y, x+1].tag == "Wall 3"))
                                {
                                    transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                                }
                            }
                            else if (y > 0 && y < transArray.GetLength(0) - 1 && x == transArray.GetLength(1) - 1)
                            {
                                if (((transArray[y - 1, x].tag == "Wall 2" && transArray[y - 1, x].rotation.eulerAngles.z == 90f) || transArray[y - 1, x].tag == "Wall 1" && (transArray[y - 1, x].rotation.eulerAngles.z == 0 || transArray[y - 1, x].rotation.eulerAngles.z == 270f))
                                    && ((transArray[y, x-1].tag == "Wall 4" && transArray[y, x-1].rotation.eulerAngles.z == 0f) || transArray[y, x-1].tag == "Wall 3" && (transArray[y, x-1].rotation.eulerAngles.z == 0f || transArray[y, x-1].rotation.eulerAngles.z == 90f)))
                                {
                                    transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                                }
                                else if (((transArray[y + 1, x].tag == "Wall 2" && transArray[y + 1, x].rotation.eulerAngles.z == 90f) || transArray[y - 1, x].tag == "Wall 1")
                                    && ((transArray[y, x - 1].tag == "Wall 4" && transArray[y, x - 1].rotation.eulerAngles.z == 0f) || transArray[y, x - 1].tag == "Wall 3" && (transArray[y, x - 1].rotation.eulerAngles.z == 0f || transArray[y, x - 1].rotation.eulerAngles.z == 90f)))
                                {
                                    transArray[y, x].transform.localScale = new Vector3(-1, 1, 1);
                                    transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                                }
                            }
                            //-------------
                            else if (x == transArray.GetLength(1)-1)
                            {
                                if (transArray[y-1, x].tag == "Wall 4" && transArray[y-1, x].transform.rotation.eulerAngles.z == 90f)
                                {
                                    transArray[y, x].transform.localScale = new Vector3(1, -1, 1);
                                }
                            }
                            else if(x == 0)
                            {
                                if (y == 0)
                                {
                                    if (transArray[y, x + 1].tag == "Wall 2" && ((transArray[y + 1, x].tag == "Wall 4") || (transArray[y + 1, x].tag == "Wall 3")))
                                    {
                                        transArray[y, x].transform.localScale = new Vector3(-1, 1, 1);
                                    }
                                }
                                else
                                {
                                    if (transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].transform.rotation.eulerAngles.z == 90f)
                                    {
                                        transArray[y, x].transform.localScale = new Vector3(-1, -1, 1);
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        switch (transArray[y, x].tag)
                        {
                            case "Wall 1":
                                if(y == 0)
                                {
                                    if (transArray[y, x-1].tag == "Wall 2" || transArray[y, x-1].tag == "Wall 1" && (transArray[y, x-1].rotation.eulerAngles.z == 0f))
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                                    }
                                }
                                else if (y < transArray.GetLength(0) - 1)
                                {
                                    if (transArray[y, x - 1].tag == "Wall 2" && transArray[y + 1, x].tag == "Wall 2")
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                                    }
                                    else if (transArray[y - 1, x].tag == "Wall 2" && transArray[y, x - 1].tag == "Wall 2")
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                                    }

                                }
                                else if (y == transArray.GetLength(0) - 1)
                                {
                                    if (transArray[y - 1, x].tag == "Wall 2" && transArray[y, x - 1].tag == "Wall 2")
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                                    }
                                }
                                else
                                {
                                    transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                                }
                                break;
                            case "Wall 3":
                                if(x != 0)
                                {
                                    if ((transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].transform.rotation.eulerAngles.z == 90f) && transArray[y, x - 1].tag != "Wall 4" && transArray[y + 1, x].tag != "Wall 4")
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                                    }
                                    if ((transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].transform.rotation.eulerAngles.z == 90f) && (transArray[y, x -1].tag == "Wall 4" && transArray[y, x - 1].transform.rotation.eulerAngles.z == 0f) )
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                                    }
                                    else if ((transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].transform.rotation.eulerAngles.z == 90f) && (transArray[y, x - 1].tag == "Wall 4" && transArray[y, x - 1].transform.rotation.eulerAngles.z == 0f))
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                                    }
                                }
                                else
                                {
                                    if ((transArray[y-1, x].tag =="Wall 4" && transArray[y - 1, x].transform.rotation.eulerAngles.z == 90f) && (transArray[y, x+1].tag == "Wall 4" && transArray[y, x+1].transform.rotation.eulerAngles.z == 0f))
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 90f, Space.Self);
                                    }
                                    else if ((transArray[y - 1, x].tag == "Wall 4" && transArray[y - 1, x].transform.rotation.eulerAngles.z == 90f) && transArray[y, x + 1].tag != "Wall 4" && transArray[y + 1, x].tag != "Wall 4")
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 180f, Space.Self);
                                    }
                                    else if ((transArray[y-1, x].tag != "Wall 4" ) && (transArray[y, x+1].tag != "Wall 4"))
                                    {
                                        transArray[y, x].transform.Rotate(0, 0, 270f, Space.Self);
                                    }
                                }


                                break;
                            default:
                                break;

                        }
                    }
                    catch (Exception g)
                    {

                    }

                }
            }
        }
    }

    private void generate(int[,] levelMap)
    {
        for (int x = 0; x < levelMap.GetLength(1); x++)        //y location
        {
            for (int y = 0; y < levelMap.GetLength(0); y++)    //x location
            {
                switch (levelMap[y, x])
                {
                    case 0: //do nothing
                        transArray[y, x] = Instantiate(new GameObject("empty"), new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        break;
                    case 1:
                        transArray[y, x] = Instantiate(sprite1, new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        break;
                    case 2:
                        transArray[y, x] = Instantiate(sprite2, new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        break;
                    case 3:
                        transArray[y, x] = Instantiate(sprite3, new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        break;
                    case 4:
                        transArray[y, x] = Instantiate(sprite4, new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        break;
                    case 5:
                        transArray[y, x] = Instantiate(sprite5, new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        transArray[y, x] = Instantiate(normalPellet, new Vector3(startX + x, startY - y, 1), Quaternion.identity).transform;
                        break;
                    case 6:
                        transArray[y, x] = Instantiate(sprite6, new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        transArray[y, x] = Instantiate(powerPellet, new Vector3(startX + x, startY - y, 1), Quaternion.identity).transform;
                        break;
                    case 7:
                        transArray[y, x] = Instantiate(sprite7, new Vector3(startX + x, startY - y, 0), Quaternion.identity).transform;
                        break;
                }
            }
        }
    }

}
