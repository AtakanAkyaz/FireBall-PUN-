using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;

public class playerManager : MonoBehaviourPunCallbacks
{
    private PhotonView PV;
    // Start is called before the first frame update
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (PV.IsMine)
        {
            CreateContrller();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateContrller()
    {
        PhotonNetwork.Instantiate(Path.Combine("Photon", "Charater"),new Vector3(Random.Range(2f,17f),1f,Random.Range(1f,27f)), Quaternion.identity);
    }
}
