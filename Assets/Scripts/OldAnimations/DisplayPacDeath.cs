using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPacDeath : MonoBehaviour
{
    [SerializeField] private GameObject item;
    public Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator death()
    {
        while (!false)
        {
            animatorController.SetTrigger("Death");
            yield return new WaitForSeconds(2.5f);
        }
    }
}
