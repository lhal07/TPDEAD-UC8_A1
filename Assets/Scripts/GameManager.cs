using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourPunCallbacks {

    public GameObject playerPrefab;

    private void Start() {
        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
            return;
        }
        Debug.Log("Instantiate Player");
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, -1, 0), Quaternion.identity);
        Debug.Log(playerPrefab.name);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(3);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

    }

}
