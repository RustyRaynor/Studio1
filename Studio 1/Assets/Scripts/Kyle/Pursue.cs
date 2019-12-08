using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour
{
    public Movement target;
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
        pursue();   
    }

    public void pursue()
    {
        Vector3 distanceT = target.transform.position - transform.position;
        float T = distanceT.magnitude / maxVelocity;
        futurePos = target.transform.position + target.velocity * T;

        transform.position += velocity * Time.deltaTime;
        //desiredVelocity = (target.transform.position - transform.position).normalized * maxVelocity;
        desiredVelocity = futurePos - transform.position;

        float distance = desiredVelocity.magnitude;

        if (distance < slowingR)
        {
            desiredVelocity = desiredVelocity.normalized * maxVelocity * (distance / slowingR);
        }
        else
        {
            desiredVelocity = desiredVelocity.normalized * maxVelocity;
        }

        Vector3 turn = (target.transform.position - transform.position).normalized - velocity;
        turn = Vector3.ClampMagnitude(turn, maxForce);
        turn = turn / mass;
        velocity = Vector3.ClampMagnitude(velocity + turn * Time.deltaTime, maxVelocity);
        transform.position += velocity * Time.deltaTime;

        //return pursue(futurePos);
    }
}
