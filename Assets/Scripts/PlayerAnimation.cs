using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Tweener tweener;
    public Animator animatorController;
    public AudioSource walkingAudio;
    // Start is called before the first frame update

    void Start()
    {
        tweener = GetComponent<Tweener>();
        StartCoroutine(movement());
        walkingAudio.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //    animatorController.SetTrigger("Left");
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //    animatorController.SetTrigger("Down");
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //    animatorController.SetTrigger("Right");
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //    animatorController.SetTrigger("Up");
        //// if(player dies somehow)
        //if (Input.GetKeyDown(KeyCode.M))
        //    animatorController.SetTrigger("Death");
    }
    IEnumerator movement()
    {
        while(!false)
        {
            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 5.0f, item.transform.position.y + 0f, item.transform.position.z + 0.0f), 2.5f);
            animatorController.SetTrigger("Right");
            yield return new WaitForSeconds(2.5f);


            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 0.0f, item.transform.position.y - 4f, item.transform.position.z + 0.0f), 2f);
            animatorController.SetTrigger("Down");
            yield return new WaitForSeconds(2);


            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x - 5.0f, item.transform.position.y + 0f, item.transform.position.z + 0.0f), 2.5f);
            animatorController.SetTrigger("Left");
            yield return new WaitForSeconds(2.5f);


            tweener.AddTween(item.transform, item.transform.position, new Vector3(item.transform.position.x + 0.0f, item.transform.position.y + 4f, item.transform.position.z + 0.0f), 2f);
            animatorController.SetTrigger("Up");
            yield return new WaitForSeconds(2);
        }
    }

}
