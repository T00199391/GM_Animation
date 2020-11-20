using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    Animator model_animator;
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        model_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            model_animator.SetBool("isWalking", true);
        }
        else
        {
            model_animator.SetBool("isWalking", false);
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4f;
            model_animator.SetBool("isRunning", true);
        }
        else
        {
            speed = 2f;
            model_animator.SetBool("isRunning", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            model_animator.SetBool("isJumping", true);
        }
        else
        {
            model_animator.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            model_animator.SetBool("isAttacking", true);
        }
        else
        {
            model_animator.SetBool("isAttacking", false);
        }

        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        
    }

    public void Move(float x, float y)
    {
        model_animator.SetFloat("Ver_X", x);
        model_animator.SetFloat("Hor_Y", y);

        transform.position += (Vector3.forward * speed) * y * Time.deltaTime;
        transform.position += (Vector3.right * speed) * x * Time.deltaTime;
    }
}
