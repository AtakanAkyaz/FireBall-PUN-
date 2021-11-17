using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player =  PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(4.4f, 17f), 1f, Random.Range(0.3f, 24f)), Quaternion.identity);
    }
}
    