using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ItemControler : MonoBehaviour
{
    protected Animator animator;
    public GameObject head;
    private GameObject lookObj = null;
    public GameObject prefab;
    private int numWeapons = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.ikActive = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) && numWeapons == 0)
        {
            Instantiate(prefab, new Vector3(0.02594393f, 0.017f, 1.089f), Quaternion.identity);
            numWeapons++;
        }

        lookObj = GameManager.DetermineObject(this.gameObject, 5);

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnAnimatorIK();
            PlaceItem();
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
        GameObject hat = GameManager.DetermineObject(this.gameObject, 0.3f);

        if (hat != null)
        {
            animator.SetLookAtWeight(0);
            GameManager.ikActive = false;

            if (!GameManager.ikActive)
            {
                hat.transform.SetParent(head.transform);
                hat.transform.position = head.transform.position;
            }
        }
    }
}
