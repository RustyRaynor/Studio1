﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameManager game;

    public float rotSpeed;
    public float minX;
    public float maxX;

    Vector3 rot;

    void Start()
    {
        game = GetComponent<GameManager>();
    }

    void LateUpdate()
    {
        CamMove();
    }

    void CamMove()
    {
        if (game.pause != true)
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            rot.y += x * rotSpeed * Time.deltaTime;
            rot.x += y * rotSpeed * Time.deltaTime;

            rot.x = Mathf.Clamp(rot.x, minX, maxX);

            transform.rotation = Quaternion.Euler(-rot.x, rot.y, 0.0f);
        }
    }
}
