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
    public AudioClip[] walkingSounds;
    public ParticleSystem particles;

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
        //Debug.Log("current: " + currentInput + " last: " + lastInput);
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = KeyCode.A;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = KeyCode.S;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = KeyCode.D;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = KeyCode.W;
        }

        if (!tweener.TweenExists(item.transform))
        {
            if (!checkPosition(lastInput))
            {
                if (checkPosition(currentInput))
                {
                    startMoving();
                    switch (currentInput)
                    {
                        case KeyCode.A:
                            moveLeftCurrent();
                            break;
                        case KeyCode.S:
                            moveDownCurrent();
                            break;
                        case KeyCode.D:
                            moveRightCurrent();
                            break;
                        case KeyCode.W:
                            moveUpCurrent();
                            break;
                        default:
                            lastInput = KeyCode.None;
                            break;
                    }
                }
                else
                {
                    currentInput = KeyCode.None;
                    walkingAudio.Stop();
                    animatorController.enabled = false;
                    particles.Stop();
                }
            }
            else
            {
                startMoving();
                switch (lastInput)
                {
                    case KeyCode.A:
                        moveLeft();
                        break;
                    case KeyCode.S:
                        moveDown();
                        break;
                    case KeyCode.D:
                        moveRight();
                        break;
                    case KeyCode.W:
                        moveUp();
                        break;
                }
            }
        }
    }

    private void startMoving()
    {
        if (animatorController.enabled == false)
        {
            animatorController.enabled = true;
        }
        if (!walkingAudio.isPlaying)
        {
            //walkingAudio.Play();
            walkingAudio.clip = walkingSounds[0];
            walkingAudio.Play();
        }
        if (!particles.isPlaying)
        {
            particles.Play();
        }
    }

    public void moveUp()
    {
        animatorController.SetTrigger("Up");
        currentInput = lastInput;
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y + 1, 0f), 0.4f);
        currentPosY -= 1;
    }

    public void moveLeft()
    {
        animatorController.SetTrigger("Left");
        currentInput = lastInput;
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x - 1, item.transform.position.y, 0f), 0.4f);
        currentPosX -= 1;
    }

    public void moveDown()
    {
        animatorController.SetTrigger("Down");
        currentInput = lastInput;
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y - 1, 0f), 0.4f);
        currentPosY += 1;
    }

    public void moveRight() 
    {
        animatorController.SetTrigger("Right");
        currentInput = lastInput;
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 1, item.transform.position.y, 0f), 0.4f);
        currentPosX += 1;
    }

    public void moveUpCurrent()
    {
        animatorController.SetTrigger("Up");
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y + 1, 0f), 0.4f);
        currentPosY -= 1;
    }

    public void moveLeftCurrent()
    {
        animatorController.SetTrigger("Left");
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x - 1, item.transform.position.y, 0f), 0.4f);
        currentPosX -= 1;
    }

    public void moveDownCurrent()
    {
        animatorController.SetTrigger("Down");
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x, item.transform.position.y - 1, 0f), 0.4f);
        currentPosY += 1;
    }

    public void moveRightCurrent()
    {
        animatorController.SetTrigger("Right");
        tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 1, item.transform.position.y, 0f), 0.4f);
        currentPosX += 1;
    }

    private bool checkPosition(int checkX, int checkY)
    {
        if (newLevelMap[checkY, checkX]== 5 || newLevelMap[checkY, checkX] == 6 || newLevelMap[checkY, checkX] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }                
    }

    private bool checkPosition(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A:
                return checkPosition(currentPosX - 1, currentPosY);
            case KeyCode.S:
                return checkPosition(currentPosX, currentPosY + 1);
            case KeyCode.D:
                return checkPosition(currentPosX + 1, currentPosY);
            case KeyCode.W:
                return checkPosition(currentPosX, currentPosY - 1);
            default:
                return false;
        }
    }
}
