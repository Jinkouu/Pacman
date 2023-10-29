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
        Debug.Log("bb");
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
        Debug.Log("aa");
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
}
