using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
<<<<<<< HEAD

     public float speed;
     public int attackDamage;
     public float attackRate;
     public int health;
     public int index = 0;
    
     public int fieldOfView = 110;
    
     public SphereCollider sphere;
    
     public bool playerDetected = false;
    
     public Collider publicCollider;
    public Collider weaponCollider;
    
     public Animator anim;
    
     public Vector3[] patrolPosition = new Vector3[3];
     public Vector3[] patrol;
    
=======
    public float speed;
    public int attackDamage;
    public float attackRate;
    public int health;
>>>>>>> 4d9d41c8bfa8b2a7ff9a772dcc0d9ed05f2fd861

    public float maxForce;
    public float mass;
    public float slowingR;
    public float deathTime;
    public float maxSeeAhead;
    public float maxAvoidanceForce;
<<<<<<< HEAD
    public float enemyRadius;
=======
    public float waitTimeRate = 3f;
    public float waitTime;

    public float walkSpeed;
    public float runSpeed;
>>>>>>> 4d9d41c8bfa8b2a7ff9a772dcc0d9ed05f2fd861

    public bool dead = false;
    public bool lastKnown;

    public Vector3 velocity;
    public Vector3 desiredVelocity;
    public Vector3 nonSpeedVelocity;
    public Vector3 avoidance;
    public Vector3 steering;
<<<<<<< HEAD
   
=======
    public Vector3 lastKnownLocation;

    public int fieldOfView = 110;

    public SphereCollider sphere;

    public bool playerDetected = false;

    public Collider publicCollider;

    public Animator anim;

    public Vector3[] patrolPosition = new Vector3[3];

>>>>>>> 4d9d41c8bfa8b2a7ff9a772dcc0d9ed05f2fd861
    public Node node;

    public GameObject player;
    public GameObject raycastPosition;

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
        if (dead == true)
        {
            StartCoroutine("Death");
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    public void Move(Vector3 target)
    {
        steering = steering * 0;
        steering = Seek(target);
        steering = steering + CollisionAvoidance();
        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, speed);
        transform.position += velocity * Time.deltaTime;
        transform.LookAt(target);
    }

    public Vector3 Seek(Vector3 target)
    {
        desiredVelocity = target - transform.position;
        nonSpeedVelocity = desiredVelocity.normalized;
        desiredVelocity = desiredVelocity.normalized * speed;
        return desiredVelocity - velocity;
    }

    public Vector3 CollisionAvoidance()
    {
        Vector3 ahead = transform.position + nonSpeedVelocity * maxSeeAhead;
        Vector3 ahead2 = transform.position + nonSpeedVelocity * maxSeeAhead * 0.5f;

        Collider mostThreatening = null;

        ahead2.y = raycastPosition.transform.position.y;
        ahead.y = raycastPosition.transform.position.y;

        Debug.DrawLine(raycastPosition.transform.position, ahead);
        Debug.DrawLine(raycastPosition.transform.position, ahead2, Color.red);

        RaycastHit hit;

        if (Physics.Linecast(raycastPosition.transform.position, ahead, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Objects") || (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")))
            {
                Debug.Log("ahead");
                mostThreatening = hit.collider;
                avoidance = ahead - hit.collider.bounds.center;
            }
        }
        if (Physics.Linecast(raycastPosition.transform.position, ahead2, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Objects") || (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")))
            {
                Debug.Log("ahead2");
                mostThreatening = hit.collider;
                avoidance = ahead2 - hit.collider.bounds.center;
            }
        }
        if (mostThreatening != null)
        {
            avoidance = avoidance.normalized * maxAvoidanceForce;
        }
        else
        {
            avoidance = avoidance * 0;
            return avoidance;
        }
        return avoidance;
    }
<<<<<<< HEAD

    public void EnableCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableCollider()
    {
        weaponCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            health -= attackDamage;
        }
    }
}
=======
}
>>>>>>> 4d9d41c8bfa8b2a7ff9a772dcc0d9ed05f2fd861
