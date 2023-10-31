using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class GhostController : MonoBehaviour
{
    public GameObject[] ghosts;
    private int[,] newLevelMap;
    public Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        GameObject levelObj = GameObject.FindGameObjectWithTag("LevelMap");
        LevelMap controller = levelObj.GetComponent<LevelMap>();
        newLevelMap = controller.getLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(isNormal)
        {
            moveGhostOne(ghosts[0]);
            moveGhostOne(ghosts[1]);
            moveGhostThree(ghosts[2]);
        }
    }

    public bool isScared = false;

    public void stopMoving()
    {
        isNormal = false;
        foreach (var ghost in ghosts)
        {
            try
            {
                Animator animatorController = ghost.GetComponent<Animator>();
                animatorController.enabled = false;
            }
            catch
            {

            }

        }
    }

    public void startMoving()
    {
        isNormal = true;
        
        //while (isNormal)
        //{
        //    moveGhostOne(ghosts[0]);
        //}
        

    }
    public void moveGhostOne(GameObject ghost)
    {
        Animator animatorController = ghost.GetComponent<Animator>();
        animatorController.enabled = true;
        Ghost ghostCon = ghost.GetComponent<Ghost>();
        int currentX = ghostCon.currentX;
        int currentY = ghostCon.currentY;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float currentDist = Vector2.Distance(player.transform.position, ghost.transform.position);

        if (!tweener.TweenExists(ghost.transform))
        {
            List<int> valid = new List<int>();

            for (int i = 0; i <= 3; i++)
            {
                if (checkPosition(i, ghostCon))
                {
                    if (!oppositeDirection(ghostCon.lastInput, i))
                    {
                        int newX = currentX;
                        int newY = currentY;
                        switch (i)
                        {
                            case 0: //left
                                newX--;
                                break;
                            case 1: //down
                                newY++;
                                break;
                            case 2: //right
                                newX++;
                                break;
                            case 3: //up
                                newY--;
                                break;
                        }

                        float newDist = Vector2.Distance(player.transform.position, new Vector3(newX, newY, 0f));
                        if (newDist >= currentDist)
                        {
                            valid.Add(i);
                        }
                    }
                }
            }

            if (valid.Count > 0)
            {
                int newInput = valid[Random.Range(0, valid.Count)];
                ghostCon.lastInput = newInput;

                 switch (newInput)
                 {
                     case 0:
                         moveLeft(ghostCon, animatorController);
                         break;
                     case 1:
                         moveDown(ghostCon, animatorController);
                         break;
                     case 2:
                         moveRight(ghostCon, animatorController);
                         break;
                     case 3:
                         moveUp(ghostCon, animatorController);
                         break;
                 }
            }
        }
    }

    public void moveGhostTwo(GameObject ghost)
    {
        Animator animatorController = ghost.GetComponent<Animator>();
        animatorController.enabled = true;
        Ghost ghostCon = ghost.GetComponent<Ghost>();
        int currentX = ghostCon.currentX;
        int currentY = ghostCon.currentY;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float currentDist = Vector2.Distance(player.transform.position, ghost.transform.position);

        if (!tweener.TweenExists(ghost.transform))
        {
            List<int> valid = new List<int>();

            for (int i = 0; i <= 3; i++)
            {
                if (checkPosition(i, ghostCon))
                {
                    if (!oppositeDirection(ghostCon.lastInput, i))
                    {
                        int newX = currentX;
                        int newY = currentY;
                        switch (i)
                        {
                            case 0: //left
                                newX--;
                                break;
                            case 1: //down
                                newY++;
                                break;
                            case 2: //right
                                newX++;
                                break;
                            case 3: //up
                                newY--;
                                break;
                        }

                        float newDist = Vector2.Distance(player.transform.position, new Vector3(newX, newY, 0f));
                        if (newDist <= currentDist)
                        {
                            valid.Add(i);
                        }
                    }
                }
            }

            if (valid.Count > 0)
            {
                int newInput = valid[Random.Range(0, valid.Count)];
                ghostCon.lastInput = newInput;

                switch (newInput)
                {
                    case 0:
                        moveLeft(ghostCon, animatorController);
                        break;
                    case 1:
                        moveDown(ghostCon, animatorController);
                        break;
                    case 2:
                        moveRight(ghostCon, animatorController);
                        break;
                    case 3:
                        moveUp(ghostCon, animatorController);
                        break;
                }
            }
        }
    }

    public void moveGhostThree(GameObject ghost)
    {
        Animator animatorController = ghost.GetComponent<Animator>();
        animatorController.enabled = true;
        Ghost ghostCon = ghost.GetComponent<Ghost>();
        //int currentX = ghostCon.currentX;
        //int currentY = ghostCon.currentY;
        int newInput;

        do
        {
            newInput = Random.Range(0, 4);
        }
        while (oppositeDirection(ghostCon.lastInput, newInput));
        ghostCon.lastInput = newInput;

        if (!tweener.TweenExists(ghost.transform))
        {
            if (checkPosition(ghostCon.lastInput, ghostCon))
            {
                switch (ghostCon.lastInput)
                {
                    case 0:
                        moveLeft(ghostCon, animatorController);
                        break;
                    case 1:
                        moveDown(ghostCon, animatorController);
                        break;
                    case 2:
                        moveRight(ghostCon, animatorController);
                        break;
                    case 3:
                        moveUp(ghostCon, animatorController);
                        break;
                }
            }
        }
    }

    private bool oppositeDirection(int lastInput, int newInput)
    {
        int[] oppositeDirection = {2, 3, 0, 1};
        return newInput == oppositeDirection[lastInput];
    }

    private bool checkPosition(int key, Ghost ghostCon)
    {
        switch (key)
        {
            case 0:
                return checkPosition(ghostCon.currentX - 1, ghostCon.currentY, ghostCon);
            case 1:
                return checkPosition(ghostCon.currentX, ghostCon.currentY + 1, ghostCon);
            case 2:
                return checkPosition(ghostCon.currentX + 1, ghostCon.currentY, ghostCon);
            case 3:
                return checkPosition(ghostCon.currentX, ghostCon.currentY - 1, ghostCon);
            default:
                return false;
        }
    }

    private bool checkPosition(int checkX, int checkY, Ghost ghost)
    {
        try
        {
            if (newLevelMap[checkY, checkX] == 5 || newLevelMap[checkY, checkX] == 6 || newLevelMap[checkY, checkX] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            //need to change so that it walks backwards on teleporters
            if (ghost.transform.position.x == 0)
            {
                moveRight(ghost, ghost.GetComponent<Animator>());
                ghost.lastInput = 2;
                //item.transform.position = new Vector3(27f, -14, 0);
                //currentPosX = 27;
                return true;
            }
            else if (ghost.transform.position.x == 27)
            {
                moveLeft(ghost, ghost.GetComponent<Animator>());
                ghost.lastInput = 0;
                //item.transform.position = new Vector3(0f, -14, 0);
                //currentPosX = 0;
                return true;
            }
            return false;
        }
    }

    public void moveUp(Ghost ghost, Animator animatorController)
    {
        animatorController.SetTrigger("Up");
        ghost.currentInput = ghost.lastInput;
        tweener.AddTween(ghost.transform, ghost.transform.position, new Vector3(ghost.transform.position.x, ghost.transform.position.y + 1, 0f), 0.4f);
        ghost.currentY -= 1;
    }

    public void moveLeft(Ghost ghost, Animator animatorController)
    {
        animatorController.SetTrigger("Left");
        ghost.currentInput = ghost.lastInput;
        tweener.AddTween(ghost.transform, ghost.transform.position, new Vector3(ghost.transform.position.x - 1, ghost.transform.position.y, 0f), 0.4f);
        ghost.currentX -= 1;
    }

    public void moveDown(Ghost ghost, Animator animatorController)
    {
        animatorController.SetTrigger("Down");
        ghost.currentInput = ghost.lastInput;
        tweener.AddTween(ghost.transform, ghost.transform.position, new Vector3(ghost.transform.position.x, ghost.transform.position.y - 1, 0f), 0.4f);
        ghost.currentY += 1;
    }

    public void moveRight(Ghost ghost, Animator animatorController)
    {
        animatorController.SetTrigger("Right");
        ghost.currentInput = ghost.lastInput;
        tweener.AddTween(ghost.transform, ghost.transform.position, new Vector3(ghost.transform.position.x + 1, ghost.transform.position.y, 0f), 0.4f);
        ghost.currentX += 1;
    }

    public void scaredState()
    {
        isNormal = false;
        isScared = true;
        foreach(var ghost in ghosts)
        {
            try
            {
                Animator animatorController = ghost.GetComponent<Animator>();
                animatorController.SetTrigger("Scared");
            }
            catch{

            }

        }
    }

    public bool isRecovery = false;
    public void recoveryState()
    {
        isScared = false;
        isRecovery = true;
        foreach (var ghost in ghosts)
        {
            Animator animatorController = ghost.GetComponent<Animator>();
            animatorController.SetTrigger("Recovery");
        }
    }

    public bool isNormal = false;

    public void normalState()
    {
        isRecovery = false;
        isNormal = true;
        foreach (var ghost in ghosts)
        {
            Animator animatorController = ghost.GetComponent<Animator>();
            animatorController.SetTrigger("Up");
            //StartCoroutine(normalDisplayAnimation(animatorController));
        }
    }

    IEnumerator normalDisplayAnimation(Animator animatorController)
    {
        while (isNormal)
        {
            animatorController.SetTrigger("Up");
            yield return new WaitForSeconds(2f);
            animatorController.SetTrigger("Right");
            yield return new WaitForSeconds(2f);
            animatorController.SetTrigger("Down");
            yield return new WaitForSeconds(2f);
            animatorController.SetTrigger("Left");
            yield return new WaitForSeconds(2f);
        }
    }

    public void deadState(GameObject ghost)
    {
        ghost.GetComponent<BoxCollider2D>().enabled = false;
        Animator animatorController = ghost.GetComponent<Animator>();
        Ghost ghostCon = ghost.GetComponent<Ghost>();
        animatorController.SetTrigger("DeadUp");
        tweener.AddTween(ghost.transform, ghost.transform.position, new Vector3(ghostCon.getStartX(), ghostCon.getStartY(), 0f), 5f);
    }

    public void ghostTimer(GameObject ghost)
    {
        StartCoroutine(ghostTimers(ghost));
    }

    IEnumerator ghostTimers(GameObject ghost)
    {
        Animator animatorController = ghost.GetComponent<Animator>();
        yield return new WaitForSeconds(5f);
        animatorController.SetTrigger("Up");
        ghost.GetComponent<BoxCollider2D>().enabled = true;
    }
}
