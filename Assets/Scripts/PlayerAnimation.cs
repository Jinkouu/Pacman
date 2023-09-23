using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            animatorController.SetTrigger("Left");
        if (Input.GetKeyDown(KeyCode.S))
            animatorController.SetTrigger("Down");
        if (Input.GetKeyDown(KeyCode.D))
            animatorController.SetTrigger("Right");
        if (Input.GetKeyDown(KeyCode.W))
            animatorController.SetTrigger("Up");
    }
}
