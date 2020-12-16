using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> weapons = new List<GameObject>();
    public static bool ikActive { get; set; }
    private static int numWeapons = 0;

    void Update()
    {
        WeaponsList();
    }

    public static List<GameObject> WeaponsList()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
        {
            weapons.Add(obj);
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

    public static void SpawnObject(GameObject prefab)
    {
        if (Input.GetKeyDown(KeyCode.O) && numWeapons == 0)
        {
            PhotonNetwork.Instantiate(Path.Combine("Photon", "Weapon"), new Vector3(0.02594393f, 0.017f, 1.089f), Quaternion.identity);
            numWeapons++;
        }
    }
}
