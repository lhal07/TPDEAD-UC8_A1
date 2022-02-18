using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connections : MonoBehaviourPunCallbacks
{

    bool m_TryingToConnectToGame = false;
    public void ConnectToGame()
    {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.ConnectUsingSettings();
        }
        else {
            m_TryingToConnectToGame = true;
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnConnectedToMaster()
    {
        if (m_TryingToConnectToGame) {
            Debug.Log("Connecting to Master Server...");
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        Debug.Log("Failed to connect: " + cause);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
        m_TryingToConnectToGame = false;
        PhotonNetwork.LoadLevel("Arena");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Could not join room. Creating new room...");
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4;
        PhotonNetwork.CreateRoom("uc8a1",ro);
    }

    public void DisconnectFromGame()
    {
        PhotonNetwork.LeaveRoom(true);
        PhotonNetwork.LoadLevel(0);
    }
}
