﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float maxDist;
    public float minDist;
    float distance;
    public float smooth;

    Vector3 normDir;

    void Awake()
    {
        normDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void Update()
    {
        Vector3 desiredCamPos = transform.parent.TransformPoint(normDir * maxDist);

        RaycastHit hit;
        if(Physics.Linecast(transform.parent.position, desiredCamPos, out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.9f, minDist, maxDist);
        }
        else
        {
            distance = maxDist;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, distance * normDir, Time.deltaTime * smooth);
    }
}
