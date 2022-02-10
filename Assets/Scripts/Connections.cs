using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connections : MonoBehaviourPunCallbacks
{
    public void ConnectToGame()
    {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.ConnectUsingSettings();
        }
        else {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecting to Master Server...");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        Debug.Log("Failed to connect: " + cause);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
        PhotonNetwork.LoadLevel("Fase01");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Could not join room. Creating new room...");
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4;
        PhotonNetwork.CreateRoom("uc8a1",ro);
    }
}
