using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourPunCallbacks {

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    private void Start() {
        if ((player1Prefab == null) || (player2Prefab == null)) {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
            return;
        }
        Debug.Log("Instantiate Player");
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1) {
            PhotonNetwork.Instantiate(player1Prefab.name, new Vector3(0, -1, 0), Quaternion.identity);
        } else if(PhotonNetwork.CurrentRoom.PlayerCount == 2) {
            PhotonNetwork.Instantiate(player2Prefab.name, new Vector3(0, -1, 0), Quaternion.identity);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
//        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
//        {
//            PhotonNetwork.LeaveRoom();
//            SceneManager.LoadScene(0);
//        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

    }

}
