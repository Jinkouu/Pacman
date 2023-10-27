using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource normal;
    public AudioSource intro;
    public AudioSource scared;

    // Start is called before the first frame update
    void Start()
    {
        intro.Play();
        normal.PlayDelayed(intro.clip.length+1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playScared()
    {
        intro.Stop();
        normal.Stop();
        StartCoroutine(scaredTimer());
    }

    IEnumerator scaredTimer()
    {
        scared.Play();
        yield return new WaitForSeconds(10f);
        scared.Stop();
        normal.Play();
    }
}
