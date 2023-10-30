using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject[] ghosts;

    // Start is called before the first frame update
    void Start()
    {
        isNormal = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        foreach (var ghost in ghosts)
        {
            try
            {
                Animator animatorController = ghost.GetComponent<Animator>();
                animatorController.enabled = true;
            }
            catch
            {

            }

        }
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
        animatorController.SetTrigger("DeadUp");
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
