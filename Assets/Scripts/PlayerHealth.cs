using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviourPun
{
    public int health = 100;

    [PunRPC]
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
            Respawn();
    }

    void Respawn()
    {
        transform.position =
            Vector3.zero;

        health = 100;
    }
}