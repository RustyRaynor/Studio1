using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotSpeed;
    float x;
    float y;

    public GameObject player;

    void LateUpdate()
    {
        CamMove();
    }

    void CamMove()
    {
        x += Input.GetAxis("Mouse X") * rotSpeed;
        y -= Input.GetAxis("Mouse Y") * rotSpeed;
        y = Mathf.Clamp(y, -35, 80);

        this.transform.LookAt(player.transform);

        this.transform.rotation = Quaternion.Euler(y, x, 0);
        player.transform.rotation = Quaternion.Euler(0, x, 0);
    }
}
