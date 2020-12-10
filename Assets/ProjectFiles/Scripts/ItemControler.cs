using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ItemControler : MonoBehaviour
{
    protected Animator animator;
    public GameObject hand;
    private GameObject lookObj = null;
    public GameObject prefab;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.ikActive = true;
    }

    void Update()
    {
        GameManager.SpawnObject(prefab);

        lookObj = GameManager.DetermineObject(this.gameObject, 5);

        if (Input.GetKeyDown(KeyCode.E) || PlayerController.picked)
        {
            OnAnimatorIK();
            PlaceItem();
            PlayerController.picked = false;
        }
    }

    void OnAnimatorIK()
    {
        if (animator)
        {

            if (GameManager.ikActive)
            {
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.transform.position);
                }
            }
            else
            {
                animator.SetLookAtWeight(0);
            }
        }
    }

    private void PlaceItem()
    {
        GameObject weapon = GameManager.DetermineObject(this.gameObject, 0.3f);

        if (weapon != null)
        {
            animator.SetLookAtWeight(0);
            GameManager.ikActive = false;

            if (!GameManager.ikActive)
            {
                weapon.transform.SetParent(hand.transform);
                weapon.transform.position = hand.transform.position;
            }
        }
    }
}
