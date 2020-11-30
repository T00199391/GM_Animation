using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();

        SceneManager.sceneLoaded += OnSceenLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();

        SceneManager.sceneLoaded -= OnSceenLoaded;
    }

    void OnSceenLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("Photon", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
