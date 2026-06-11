using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.Instantiate(
            "PlayerPrefab",
            Random.insideUnitSphere * 5,
            Quaternion.identity);
    }
}