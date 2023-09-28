using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPacman : MonoBehaviour
{
    [SerializeField] private GameObject item;
    public Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rotate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator rotate()
    {
        while (!false)
        {
            animatorController.SetTrigger("Right");
            yield return new WaitForSeconds(2.5f);


            animatorController.SetTrigger("Down");
            yield return new WaitForSeconds(2);


            animatorController.SetTrigger("Left");
            yield return new WaitForSeconds(2.5f);


            animatorController.SetTrigger("Up");
            yield return new WaitForSeconds(2);
        }
    }
}
