using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playIntro());
    }

    IEnumerator playIntro()
    {
        source.clip = clips[0];
        source.Play();
        float introLength = clips[0].length;
        yield return new WaitForSeconds(introLength);
        source.Stop();
        source.loop = true;
        //source.clip = clips[1];
        //source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stopAudio()
    {
        source.Stop();
    }

    public void playNormal()
    {
        source.Stop();
        source.clip = clips[1];
        source.Play();
    }

    public void playScared()
    {
        StartCoroutine(scaredTimer());
    }

    IEnumerator scaredTimer()
    {
        source.Stop();
        source.clip = clips[2];
        source.Play();
        yield return new WaitForSeconds(10f);
        source.Stop();
        source.clip = clips[1];
        source.Play();
    }

    public void playDead()
    {
        StartCoroutine(deadTimer());
    }

    IEnumerator deadTimer()
    {
        source.Stop();
        source.clip = clips[3];
        source.Play();
        yield return new WaitForSeconds(5f);
        source.Stop();
        source.clip = clips[1];
        source.Play();
    }
}
