using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity;
    public float maxForce;
    public float mass;
    public float slowingR;
    Vector3 velocity;
    Vector3 desiredVelocity;
    Vector3 futurePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pursue(futurePos);   
    }

    public Vector3 pursue(Vector3 futurePos)
    {
        float T = desiredVelocity.magnitude / maxVelocity;
        futurePos = target.transform.position * T;

        transform.position += velocity;
        //desiredVelocity = (target.transform.position - transform.position).normalized * maxVelocity;
        desiredVelocity = target.transform.position - transform.position;

        float distance = desiredVelocity.magnitude;

        if (distance < slowingR)
        {
            desiredVelocity = desiredVelocity.normalized * maxVelocity * (distance / slowingR);
        }
        else
        {
            desiredVelocity = desiredVelocity.normalized * maxVelocity;
        }

        Vector3 turn = desiredVelocity - velocity;
        turn = Vector3.ClampMagnitude(turn, maxForce);
        turn = turn / mass;
        velocity = Vector3.ClampMagnitude(velocity + turn * Time.deltaTime, maxVelocity);
        transform.position += velocity * Time.deltaTime;

        return pursue(futurePos);
    }
}
