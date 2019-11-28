using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
     public float speed;
     public int attackDamage;
     public float attackRate;
     public int health;

    public float maxVelocity;
    public float maxForce;
    public float maxSpeed;
    public float mass;
    public Vector3 velocity;
    public Vector3 desiredVelocity;

    public int fieldOfView = 110;
    
     public SphereCollider sphere;
    
     public bool playerDetected = false;
    
     public Collider publicCollider;
    
     public Animator anim;
    
     public Vector3[] patrolPosition = new Vector3[3];
    
     public Node node;

     public GameObject player;

     public PlayerMovement playerCode;

    void Start()
    {
        playerCode = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
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
}
