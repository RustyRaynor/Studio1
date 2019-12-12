using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Context : MonoBehaviour
{
    public int damage;
    public int health;

    public float maxForce;
    public float maxVelocity;
    public float mass;
    public float enemyR;
    //public float slowingR;
    public float deathTime;
    public float maxSeeAhead;
    public float maxAvoidanceForce;
    public float waitTime;
    public float waitTimeR = 2.5f;

    public Vector3 velocity;
    public Vector3 desiredVelocity;
    public Vector3 avoidance;
    Vector3 futurePos;

    public int fieldOfView = 110;

    public SphereCollider sphere;

    public bool playerDetected = false;

    public bool isDead;

    public Collider publicCollider;

    public Animator anim;

    public Vector3[] patrolPosition = new Vector3[3];
    public Vector3[] patrol;

    public NodeBT nodebt;

    public GameObject player;
    public GameObject raycastPosition;

    public PlayerMovement playerCode;

    void Start()
    {
        playerCode = player.GetComponent<PlayerMovement>();
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            publicCollider = collision;
            playerDetected = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            publicCollider = collision;
            playerDetected = false;
        }
    }

    protected void Death() //Detroys skeleton when dead
    {
        if (isDead == true)
        {
            Destroy(this.gameObject);
        }
    }


    public void Seek(Vector3 target) //Chases after Player
    {

        transform.position += velocity * Time.deltaTime * anim.GetFloat("vCurve");
        desiredVelocity = (target - transform.position).normalized * maxVelocity;
        desiredVelocity = target - transform.position;
        //float distance = desiredVelocity.magnitude;
        //if (distance < slowingR)
        //{
        //    desiredVelocity = desiredVelocity.normalized * maxVelocity * (distance / slowingR);
        //}
        //else
        //{
        //    desiredVelocity = desiredVelocity.normalized * maxVelocity;
        //}
        Vector3 turn = desiredVelocity - velocity;
        turn = Vector3.ClampMagnitude(turn, maxForce);
        turn = turn / mass;
        velocity = Vector3.ClampMagnitude(velocity + turn * Time.deltaTime, maxVelocity);
        //Vector3 newVelocity = velocity + turn;
        //newVelocity = Vector3.ClampMagnitude(newVelocity, maxSpeed);  
    }

    public void Pursue(Vector3 target) // Calculates Players future position and tries to reach that point
    {
        Vector3 distanceT = target - transform.position;
        float T = distanceT.magnitude / maxVelocity;
        futurePos = target + playerCode.move * T;

        transform.position += velocity * Time.deltaTime * anim.GetFloat("vCurve");
        desiredVelocity = (target - transform.position).normalized * maxVelocity;
        desiredVelocity = futurePos - transform.position;

        Vector3 turn = (target - transform.position).normalized - velocity;
        turn = Vector3.ClampMagnitude(turn, maxForce);
        turn = turn / mass;
        velocity = Vector3.ClampMagnitude(velocity + turn * Time.deltaTime, maxVelocity);
        transform.position += velocity * Time.deltaTime;

        //return pursue(futurePos);
    }

    public Vector3 CollisionAvoidance() // Avoids obstacles that are in the way while traversing
    {
        Vector3 ahead = transform.position + velocity.normalized * maxSeeAhead;
        Vector3 ahead2 = transform.position + velocity.normalized * maxSeeAhead * 0.5f;
        ahead2.y = ahead.y;

        Collider mostThreatening = null;

        Vector3 currentPosition = transform.position;
        currentPosition.y = ahead.y;

        Debug.DrawLine(currentPosition, ahead);
        Debug.DrawLine(currentPosition, ahead2, Color.red);

        RaycastHit hit;
        RaycastHit hit2;

        if (Physics.Raycast(transform.position, ahead, out hit))
        {
            if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy" && hit.collider.tag != "floor")
            {
                mostThreatening = hit.collider;
            }
        }
        if (Physics.Raycast(transform.position, ahead2, out hit2))
        {
            if (hit2.collider.tag != "Player" && hit2.collider.tag != "Enemy" && hit2.collider.tag != "floor")
            {
                mostThreatening = hit2.collider;
            }
        }

        if (mostThreatening != null)
        {
            avoidance = ahead - mostThreatening.bounds.center;
            avoidance = avoidance.normalized * maxAvoidanceForce;
        }
        else
        {
            avoidance = avoidance * 0;
        }
        return avoidance;
    }
}
