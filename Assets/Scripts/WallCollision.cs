using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particles;
    public AudioSource collisionAudio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    Vector3 collisionPoint = other.ClosestPoint(transform.position);
        //    ParticleSystem newParticles = Instantiate(particles,collisionPoint, Quaternion.identity);
        //    newParticles.Play();
        //    collisionAudio.Play();
        //    wait();
        //    if(newParticles != null)
        //    {
        //        Destroy(newParticles);
        //    }
        //}
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //if(particles != null)
            //{
            //    particles.Stop();
            //    //Destroy
            //}
            //particles.Stop();
        }
    }
}
