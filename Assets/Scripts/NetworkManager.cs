using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using ExitGames.Client.Photon;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public TMP_Text playerListText;
    public TMP_InputField roomInput;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Update()
    {
        string players = "";

        foreach (Player p in PhotonNetwork.PlayerList)
        {
            players += p.NickName;

            if (p.CustomProperties.ContainsKey("Ready"))
                players += " READY";

            players += "\n";
        }

        playerListText.text = players;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(
            roomInput.text,
            new RoomOptions()
            {
                MaxPlayers = 4
            });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomInput.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
    }

    public void ToggleReady()
    {
        ExitGames.Client.Photon.Hashtable hash =
    new ExitGames.Client.Photon.Hashtable();

        hash["Ready"] = true;

        PhotonNetwork.LocalPlayer
            .SetCustomProperties(hash);
    }
    public void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GameScene");
        }
    }

}