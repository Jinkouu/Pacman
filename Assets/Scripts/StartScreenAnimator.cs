using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    //public RectTransform pellet;
    public Image pellet;
    public Tweener tweener;

    private List<Image> spawnedImages = new List<Image>();

    void Start()
    {
        try
        {
            //tweener = GetComponent<Tweener>();
            //StartCoroutine(createAndTween());
            StartCoroutine(loopSpawn());
        }
        catch
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator loopSpawn()
    {
        while (true)
        {
            StartCoroutine(createAndTween());
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator createAndTween()
    {
        //RectTransform[] pellets = new RectTransform[9];
        //for(int i = 0; i < 10; i++)
        //while (true)
        //{
            Image pellets = Instantiate(pellet, canvas.transform);
            //spawnedImages.Add(pellets);
            tweener.AddTween(pellets.rectTransform, new Vector3(Screen.width / 4, -25f, 0.0f), new Vector3(Screen.width / 4, Screen.height + 25f, 0.0f), 2.5f);

            Image pellets2 = Instantiate(pellet, canvas.transform);
            //spawnedImages.Add(pellets2);
            tweener.AddTween(pellets2.rectTransform, new Vector3(Screen.width / 4 * 3, Screen.height + 25f, 0.0f), new Vector3(Screen.width / 4 * 3, -25f, 0.0f), 2.5f);

            yield return new WaitForSeconds(3.5f);
            if(pellets.gameObject != null ||  pellets2.gameObject != null)
            {
                Destroy(pellets.gameObject);
                Destroy(pellets2.gameObject);
            }


    }
}
