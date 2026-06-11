using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    public float speed = 5;

    void Update()
    {
        if (!photonView.IsMine)
            return;

        float h =
            Input.GetAxis("Horizontal");

        float v =
            Input.GetAxis("Vertical");

        transform.Translate(
            new Vector3(h, 0, v)
            * speed
            * Time.deltaTime);
    }
}