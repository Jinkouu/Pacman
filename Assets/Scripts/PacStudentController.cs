using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private GameObject item;
    public Tweener tweener;
    public Animator animatorController;
    public AudioSource walkingAudio;

    private int currentPosX;
    private int currentPosY;

    private KeyCode lastInput;
    private KeyCode currentInput;

    // Start is called before the first frame update
    void Start()
    {
        currentPosX = 1;
        currentPosY = 1;
        convertLevel(levelMap);
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

    // Update is called once per frame
    void Update()
    {

        // get current input and assign last input
        // if current input is not a valid direction, continue going with the last input
        //
        if (!tweener.TweenExists(item.transform))
        {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && checkPosition(currentPosX - 1, currentPosY) == true)
            {
                animatorController.SetTrigger("Left");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x - 1, item.transform.position.y, 0f), 0.4f);
                currentPosX -= 1;
                currentInput = KeyCode.A;
            }
            else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && checkPosition(currentPosX, currentPosY + 1) == true)
            {
                animatorController.SetTrigger("Down");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y - 1, 0f), 0.4f);
                currentPosY += 1;
                currentInput = KeyCode.S;
            }
            else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && checkPosition(currentPosX + 1, currentPosY) == true)
            {
                animatorController.SetTrigger("Right");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 1, item.transform.position.y, 0f), 0.4f);
                currentPosX += 1;
                currentInput = KeyCode.D;
            }
            else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && checkPosition(currentPosX, currentPosY - 1) == true)
            {
                animatorController.SetTrigger("Up");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y + 1, 0f), 0.4f);
                currentPosY -= 1;
                currentInput = KeyCode.W;
            }
            else
            {

                switch (lastInput)
                {
                    case KeyCode.A:
                        if (checkPosition(currentPosX - 1, currentPosY) == true)
                        {
                            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x - 1, item.transform.position.y, 0f), 0.4f);
                            currentPosX -= 1;
                            lastInput = KeyCode.A;
                        }
                        else
                        {
                            lastInput = KeyCode.None;
                        }
                        break;
                    case KeyCode.S:
                        if (checkPosition(currentPosX, currentPosY + 1) == true)
                        {
                            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y - 1, 0f), 0.4f);
                            currentPosY += 1;
                            lastInput = KeyCode.S;
                        }
                        else
                        {
                            lastInput = KeyCode.None;
                        }
                        break;
                    case KeyCode.D:
                        if (checkPosition(currentPosX + 1, currentPosY) == true)
                        {
                            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 1, item.transform.position.y, 0f), 0.4f);
                            currentPosX += 1;
                            lastInput = KeyCode.D;
                        }
                        else
                        {
                            lastInput = KeyCode.None;
                        }
                        break;
                    case KeyCode.W:
                        if (checkPosition(currentPosX, currentPosY - 1) == true)
                        {
                            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y + 1, 0f), 0.4f);
                            currentPosY -= 1;
                            lastInput = KeyCode.W;
                        }
                        else
                        {
                            lastInput = KeyCode.None;
                        }
                        break;
                    default:
                        //do nothing
                        break;
                }
            }
        }

        //switch (lastInput)
        //{
        //    case KeyCode.A:
        //        if (checkPosition(currentPosX - 1, currentPosY) == true)
        //        {
        //            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x - 1, item.transform.position.y, 0f), 0.4f);
        //            currentPosX -= 1;
        //        }
        //        else
        //        {
        //            lastInput = KeyCode.None;
        //        }
        //        break;
        //    case KeyCode.S:
        //        if (checkPosition(currentPosX, currentPosY + 1) == true)
        //        {
        //            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y - 1, 0f), 0.4f);
        //            currentPosY += 1;
        //        }
        //        else
        //        {
        //            lastInput = KeyCode.None;
        //        }
        //        break;
        //    case KeyCode.D:
        //        if (checkPosition(currentPosX + 1, currentPosY) == true)
        //        {
        //            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 1, item.transform.position.y, 0f), 0.4f);
        //            currentPosX -= 1;
        //        }
        //        else
        //        {
        //            lastInput = KeyCode.None;
        //        }
        //        break;
        //    case KeyCode.W:
        //        if (checkPosition(currentPosX, currentPosY - 1) == true)
        //        {
        //            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y + 1, 0f), 0.4f);
        //            currentPosY -= 1;
        //        }
        //        else
        //        {
        //            lastInput = KeyCode.None;
        //        }
        //        break;
        //    default:
        //        //do nothing
        //        break;
        //}
    }

    private bool checkPosition(int checkX, int checkY)
    {
        Debug.Log(newLevelMap[checkY, checkX]);
        if (newLevelMap[checkY, checkX]== 5 || newLevelMap[checkY, checkX] == 6 || newLevelMap[checkY, checkX] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }                
    }


}
