using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
     public float speed;
     public int attackDamage;
     public int health;
    
     public int fieldOfView = 110;
    
     public SphereCollider sphere;
    
     public bool playerDetected = false;
    
     public Collider publicCollider;
    
     public Animator anim;
    
     public Vector3[] patrolPosition = new Vector3[3];
    
     public Node node;

     public GameObject player;

    void Start()
    {
        
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
