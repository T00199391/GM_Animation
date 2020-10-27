using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    Animator model_animator;
    // Start is called before the first frame update
    void Start()
    {
        model_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            model_animator.SetBool("isWalking", true);
        else
            model_animator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            model_animator.SetBool("isRunning", true);
        else
            model_animator.SetBool("isRunning", false);

       if (Input.GetKey(KeyCode.Space))
            model_animator.SetBool("isJumping", true);
        else
            model_animator.SetBool("isJumping", false);
    }
}
