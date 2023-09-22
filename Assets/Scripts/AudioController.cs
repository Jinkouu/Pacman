using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource normal;
    public AudioSource intro;

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
}
