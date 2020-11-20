using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> weapons = new List<GameObject>();
    public static bool ikActive { get; set; }

    void Update()
    {
        WeaponsList();
    }

    public static List<GameObject> WeaponsList()
    {
        foreach (GameObject hat in GameObject.FindGameObjectsWithTag("Weapon"))
        {
            weapons.Add(hat);
        }

        return weapons;
    }

    public static GameObject DetermineObject(GameObject character,float distance)
    {
        GameObject weapon = null;

        for (int i = 0; i < weapons.Count - 1; i++)
        {
            if (Vector3.Distance(character.transform.position, weapons[i].transform.position) < distance)
            {
                weapon = weapons[i];
            }
        }

        return weapon;
    }
}
