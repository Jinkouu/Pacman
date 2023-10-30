using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            try
            {
                GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
                Text timeText = timerObject.GetComponent<Text>();
                timeText.text = PlayerPrefs.GetString("BestTime", "00:00:00");

                GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
                Text scoreText = scoreObject.GetComponent<Text>();
                scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
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
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }

    public void LoadStartLevel()
    {
        //SceneManager.sceneLoaded += OnScreenLoad;
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(0);
    }

}
