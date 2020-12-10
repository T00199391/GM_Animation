using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    Animator model_animator;
    float speed = 2f;
    PhotonView PV;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public static bool jumped { get; set; }
    public static bool picked { get; set; }
    public static bool attacked { get; set; }

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        model_animator = GetComponent<Animator>();

        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }

        actions.Add("jump", Jump);
        actions.Add("attack", Attack);
        actions.Add("pick up", PickUp);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizeSpeech;
        keywordRecognizer.Start();
    }

    void Update()
    {
        if (!PV.IsMine)
            return;

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

        if (Input.GetKey(KeyCode.Space) || jumped)
        {
            model_animator.SetBool("isJumping", true);
            jumped = false;
        }
        else
        {
            model_animator.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.Mouse0) || attacked)
        {
            model_animator.SetBool("isAttacking", true);
            attacked = false;
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

    private void RecognizeSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }

    private void Jump()
    {
        jumped = true;
        Debug.Log("Jumped");
    }

    private void Attack()
    {
        attacked = true;
        Debug.Log("Attacked");
    }

    private void PickUp()
    {
        picked = true;
        Debug.Log("Picked up");
    }
}
