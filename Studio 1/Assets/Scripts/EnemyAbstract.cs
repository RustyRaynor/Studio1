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
    
     public Animator anim;
    
     public Vector3[] patrolPosition = new Vector3[3];
     public Vector3[] patrol;
=======
    public float speed;
    public int attackDamage;
    public float attackRate;
    public int health;

    public float maxForce;
    public float mass;
    public float slowingR;
    public float deathTime;
    public float maxSeeAhead;
    public float maxAvoidanceForce;

    public bool dead = false;

    public Vector3 velocity;
    public Vector3 desiredVelocity;
    public Vector3 avoidance;
    public Vector3 steering;

    public int fieldOfView = 110;
>>>>>>> eabf6a374b64b9dc7a32faba57504833c292ce41
    
    public SphereCollider sphere;
   
    public bool playerDetected = false;
   
    public Collider publicCollider;
   
    public Animator anim;
   
    public Vector3[] patrolPosition = new Vector3[3];
   
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
        if(dead == true)
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
        //steering = steering + CollisionAvoidance();
        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, speed);
        transform.position += velocity * Time.deltaTime;
        transform.LookAt(target);
    }

    public Vector3 Seek(Vector3 target)
    {
        desiredVelocity = target - transform.position;
        desiredVelocity = desiredVelocity.normalized * speed;
        return desiredVelocity - velocity;
    }

    public Vector3 CollisionAvoidance()
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

        if(Physics.Raycast(transform.position, ahead, out hit))
        {
            if(hit.collider.tag != "Player" && hit.collider.tag != "Enemy" && hit.collider.tag != "floor")
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

        if(mostThreatening != null)
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
