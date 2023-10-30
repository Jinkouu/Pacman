using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int highscore = 0;
    private float bestTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            try
            {
                GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
                GameTimerController timerController = timerObject.GetComponent<GameTimerController>();
                Text timeText = timerObject.GetComponent<Text>();
                bestTime = PlayerPrefs.GetFloat("BestTime", 0);
                timeText.text = timerController.convertTime(bestTime);

                GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
                Text scoreText = scoreObject.GetComponent<Text>();
                highscore = PlayerPrefs.GetInt("HighScore", 0);
                scoreText.text = highscore.ToString();
            }
            catch
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        //SceneManager.sceneLoaded += OnScreenLoad;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }

    public void LoadStartLevel()
    {
        //SceneManager.sceneLoaded += OnScreenLoad;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(0);
    }

    public void updatePrefs(int score, float time)
    {
        //PlayerPrefs.SetInt("HighScore", currentScore);
        //PlayerPrefs.SetFloat("BestTime", currentTime);
        if (score > highscore || (score == highscore && score < bestTime))
        {
            // Save the new high score and best time
            PlayerPrefs.SetInt("HighScore", score);
            GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
            GameTimerController timerController = timerObject.GetComponent<GameTimerController>();
            PlayerPrefs.SetFloat("BestTime", time);
            PlayerPrefs.Save();
        }
    }
}
