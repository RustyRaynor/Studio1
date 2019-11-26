using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 circleCenter;
    public Vector3 displacementForce;
    public Vector3 wanderForce;
    public float speed = 5f;
    public float len;
    public float circleDistance;
    public float circleRadius;
    public float wanderAngle;
    public float angleChange;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        displacementForce = new Vector3(0, 1, 0);
        angleChange = 30;
        CalcCircleCenter();
        rb.velocity = rb.velocity * speed * Time.deltaTime;
        transform.position = transform.position + rb.velocity;
        
    }
    
    void Update()
    {
        wanderAngle += (Random.Range(0f, 1f) * angleChange) - (angleChange * .5f);
        setAngle(displacementForce, wanderAngle);
        WanderForce();
    }

    public void CalcCircleCenter()
    {
        circleCenter = rb.velocity;
        circleCenter = circleCenter.normalized * circleDistance;
    }

    public Vector3 WanderForce()
    {
        wanderForce = circleCenter + displacementForce;

        return wanderForce;
    }

    public void setAngle(Vector3 displacement, float angle)
    {
        len = displacement.magnitude;
        displacement.x = Mathf.Cos(angle) * len;
        displacement.y = Mathf.Sin(angle) * len;
    }
}
