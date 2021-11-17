using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }

    }
    public void OnCreateGameButtonClicked()
    {
        Debug.Log("OnCreateGameButtonClicked");
        PhotonNetwork.CreateRoom("Room1");

    }

    public void OnJoinGameButtonClicked()
    {
        Debug.Log("OnJoinGameButtonClicked");
        PhotonNetwork.JoinRoom("Room1");

    }


    public override void OnPlayerEnteredRoom(Player other)
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}
