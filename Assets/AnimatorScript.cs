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
        {
            model_animator.SetFloat("Hor_Y", 0.0f);
            model_animator.SetFloat("Ver_X", 1.0f);
        }
        else
        {
            model_animator.SetFloat("Hor_Y", 0.0f);
            model_animator.SetFloat("Ver_X", 0.0f);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //model_animator.SetFloat("Hor_f",)
        }
    }
}
