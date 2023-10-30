using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private GameObject item;
    public Tweener tweener;
    public Animator animatorController;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public ParticleSystem walkParticles;
    public ParticleSystem collisionParticles;
    public ParticleSystem deathParticles;

    private int currentPosX;
    private int currentPosY;

    private KeyCode lastInput = KeyCode.None;
    private KeyCode currentInput = KeyCode.None;

    // Start is called before the first frame update
    void Start()
    {
        currentPosX = 1;
        currentPosY = 1;
        //convertLevel(levelMap);
        GameObject levelObj = GameObject.FindGameObjectWithTag("LevelMap");
        LevelMap controller = levelObj.GetComponent<LevelMap>();
        newLevelMap = controller.getLevel();

        StartCoroutine(roundStart());
    }
    private int[,] newLevelMap;

    private bool hasCollided = false;
    private bool startedMoving = false;
    private bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("current: " + currentInput + " last: " + lastInput);
        if (canMove)
        {
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
                        startedMoving = true;
                        hasCollided = false;
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
                        //audioSource.Stop();
                        if (!isDying)
                        {
                            animatorController.enabled = false;
                        }
                        //animatorController.enabled = false;
                        walkParticles.Stop();

                        if (hasCollided == false && startedMoving == true)
                        {
                            hasCollided = true;
                            StartCoroutine(wallCollision(lastInput));
                        }
                    }
                }
                else
                {
                    startedMoving = true;
                    hasCollided = false;
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
    }

    IEnumerator wallCollision(KeyCode key)
    {
        float collisionX = 0;
        float collisionY = 0;
        switch (key)
        {
            case KeyCode.A:
                collisionX = item.transform.position.x - 0.5f;
                collisionY = item.transform.position.y;
                break;
            case KeyCode.S:
                collisionX = item.transform.position.x;
                collisionY = item.transform.position.y + 0.5f;
                break;
            case KeyCode.D:
                collisionX = item.transform.position.x + 0.5f;
                collisionY = item.transform.position.y;
                break;
            case KeyCode.W:
                collisionX = item.transform.position.x;
                collisionY = item.transform.position.y - 0.5f;
                break;
        }

        Vector3 collisionPoint = new Vector3(collisionX, collisionY, 0);
        ParticleSystem newCollisionParticles = Instantiate(collisionParticles, collisionPoint, Quaternion.identity);
        audioSource.clip = audioClips[2];
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        Destroy(newCollisionParticles.gameObject);
        audioSource.Stop();
    }

    private void startMoving()
    {
        if (animatorController.enabled == false)
        {
            animatorController.enabled = true;
        }
        if (!audioSource.isPlaying || audioSource.clip != audioClips[0])
        {
            //audioSource.Play();
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if (!walkParticles.isPlaying)
        {
            walkParticles.Play();
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
            //where the teleporters are
            if(item.transform.position.x == 0)
            {
                item.transform.position = new Vector3(27f, -14, 0);
                currentPosX = 27;
                return true;
            }
            else if(item.transform.position.x == 27)
            {
                item.transform.position = new Vector3(0f, -14, 0);
                currentPosX = 0;
                return true;
            }
            return false;
        }              
    }

    //private int[] getPosition(KeyCode key)
    //{
    //    int[] position = new int[2];
    //    switch (key)
    //    {
    //        case KeyCode.A:
    //            position[0] = currentPosX - 1;
    //            position[1] = currentPosY;
    //            return position;
    //        case KeyCode.S:
    //            position[0] = currentPosX;
    //            position[1] = currentPosY + 1;
    //            return position;
    //        case KeyCode.D:
    //            position[0] = currentPosX + 1;
    //            position[1] = currentPosY;
    //            return position;
    //        case KeyCode.W:
    //            position[0] = currentPosX;
    //            position[1] = currentPosY - 1;
    //            return position;
    //        default:
    //            return null;
    //    }
    //}

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

    public int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gamePellet"))
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            score += 10;
            GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
            if (scoreObject != null)
            {
                Text scoreText = scoreObject.GetComponent<Text>();
                scoreText.text = score.ToString();
            }
            GameObject pelletObj = GameObject.FindGameObjectWithTag("PelletController");
            PelletController pelletController = pelletObj.GetComponent<PelletController>();
            pelletController.reducePellet();
            Destroy(other.gameObject);

            if(pelletController.getPelletCount() == 0)
            {
                StartCoroutine(handleGameOver());
            }
        }
        else if (other.CompareTag("Cherry"))
        {
            score += 100;
            GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
            if (scoreObject != null)
            {
                Text scoreText = scoreObject.GetComponent<Text>();
                scoreText.text = score.ToString();
            }
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("powerPellet"))
        {
            Destroy(other.gameObject);
            GameObject audioController = GameObject.FindGameObjectWithTag("audioController");
            AudioController controller = audioController.GetComponent<AudioController>();
            controller.playScared();
            GameObject timers = GameObject.FindGameObjectWithTag("GhostTimer");
            TimerController timer = timers.GetComponent<TimerController>();
            timer.countdown();
        }
        else if (other.CompareTag("Ghost"))
        {
            if(other.GetComponentInParent<GhostController>() != null)
            {
                GhostController ghostController = other.GetComponentInParent<GhostController>();
                if (ghostController.isNormal){ //pacman dies
                    GameObject livesController = GameObject.FindGameObjectWithTag("livesController");
                    LivesController controller = livesController.GetComponent<LivesController>();
                    if(controller.getLives() <= 1)
                    {
                        StartCoroutine(handleGameOver());
                        return;
                    }
                    firstRound = false;
                    currentInput = KeyCode.None;
                    lastInput = KeyCode.None;
                    isDying = true;
                    
                    controller.reduceLife();
                    GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
                    GameTimerController gameTimerController = timerObject.GetComponent<GameTimerController>();
                    gameTimerController.stopTimer();
                    StartCoroutine(handleDeath());
                }
                else
                {
                    ghostController.deadState(other.gameObject);
                    score += 300;
                    GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
                    if (scoreObject != null)
                    {
                        Text scoreText = scoreObject.GetComponent<Text>();
                        scoreText.text = score.ToString();
                    }
                    GameObject audioController = GameObject.FindGameObjectWithTag("audioController");
                    AudioController controller = audioController.GetComponent<AudioController>();
                    controller.playDead();
                    ghostController.ghostTimer(other.gameObject);
                }
            }
        }
    }

    IEnumerator handleGameOver()
    {
        //end game when pellets is 0
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        GameTimerController gameTimerController = timerObject.GetComponent<GameTimerController>();
        gameTimerController.stopTimer();

        //stop ghosts
        GameObject ghostsObj = GameObject.FindGameObjectWithTag("GhostController");
        GhostController ghostsController = ghostsObj.GetComponent<GhostController>();
        ghostsController.stopMoving();

        //stop player
        animatorController.enabled = false;
        walkParticles.Stop();
        currentInput = KeyCode.None;
        lastInput = KeyCode.None;

        GameObject countObject = GameObject.FindGameObjectWithTag("Countdown");
        Text countText = countObject.GetComponent<Text>();
        countText.text = "Game Over";
        yield return new WaitForSeconds(3f);
        countText.text = "";
        //SceneManager.LoadScene(0);

        //handle player prefs
        GameObject managersObj = GameObject.FindGameObjectWithTag("Managers");
        UIManager managerController = managersObj.GetComponent<UIManager>();
        managerController.updatePrefs(score, gameTimerController.getTime());
        managerController.LoadStartLevel();

    }

    private bool isDying = false;
    IEnumerator handleDeath()
    {
        canMove = false;
        deathParticles.gameObject.transform.position = item.transform.position;
        deathParticles.Play();
        animatorController.enabled = true;
        animatorController.SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);
        animatorController.SetTrigger("Down");
        item.transform.position = new Vector3(1, -1, 0);
        currentPosX = 1;
        currentPosY = 1;
        isDying = false;
        StartCoroutine(roundStart());
    }
    private bool firstRound = true;

    IEnumerator roundStart()
    {
        canMove = false;
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        GameTimerController gameTimerController = timerObject.GetComponent<GameTimerController>();
        GameObject audioController = GameObject.FindGameObjectWithTag("audioController");
        AudioController controller = audioController.GetComponent<AudioController>();
        GameObject ghostsObj = GameObject.FindGameObjectWithTag("GhostController");
        GhostController ghostsController = ghostsObj.GetComponent<GhostController>();
        ghostsController.stopMoving();

        animatorController.enabled = false;
        if (!firstRound)
        {
            controller.stopAudio();
        }
        GameObject countObject = GameObject.FindGameObjectWithTag("Countdown");
        Text countText = countObject.GetComponent<Text>();
        countText.text = "3";
        yield return new WaitForSeconds(1f);
        countText.text = "2";
        yield return new WaitForSeconds(1f);
        countText.text = "1";
        yield return new WaitForSeconds(1f);
        countText.text = "GO!";
        yield return new WaitForSeconds(1f);
        gameTimerController.startTimer();
        canMove = true;
        countText.text = "";
        controller.playNormal();
        animatorController.enabled = true;
        ghostsController.startMoving();
    }
}
