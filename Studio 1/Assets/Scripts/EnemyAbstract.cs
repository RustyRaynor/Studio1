﻿using System.Collections;
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
    public float mass;
    public float slowingR;

    protected bool dead = false;

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

    protected void Dead()
    {
        if (health <= 0)
        {
            dead = true;
        }
        if(dead == true)
        {
            anim.SetTrigger("Dead");
            dead = false;
            StartCoroutine("Death");
        }
    }
    
    IEnumerator Death()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}