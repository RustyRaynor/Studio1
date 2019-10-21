using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotSpeed;
    public float minX;
    public float maxX;

    Vector3 rot;

    void LateUpdate()
    {
        CamMove();
    }

    void CamMove()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        rot.y += x * rotSpeed * Time.deltaTime;
        rot.x += y * rotSpeed * Time.deltaTime;

        rot.x = Mathf.Clamp(rot.x, minX, maxX);

        transform.rotation = Quaternion.Euler(rot.x, rot.y, 0.0f);
    }
}
