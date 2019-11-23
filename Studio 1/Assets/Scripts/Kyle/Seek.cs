using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity;
    public float maxForce;
    public float maxSpeed;
    public float mass;
    Vector3 velocity;
    Vector3 desiredVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        seek();
    }

    public void seek()
    {
        transform.position += velocity;
        desiredVelocity = (target.transform.position - transform.position).normalized * maxVelocity;
        Vector3 turn = desiredVelocity - velocity;
        turn = Vector3.ClampMagnitude(turn, maxForce);
        turn = turn / mass;
        velocity = Vector3.ClampMagnitude(velocity + turn * Time.deltaTime, maxVelocity);
        transform.position += velocity * Time.deltaTime;
        //Vector3 newVelocity = velocity + turn;
        //newVelocity = Vector3.ClampMagnitude(newVelocity, maxSpeed);  
    }
}
