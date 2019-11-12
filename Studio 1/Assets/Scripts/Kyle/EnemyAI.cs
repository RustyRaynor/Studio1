using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform objectToChase;
    [SerializeField] Transform[] destinations;

    int currentDes = 0;

    public GameObject Enemy;

    public int EnemyHealth = 10;

    bool Attacked = false;

    //public float attackdist;
    //float distance;

    enum EnemyStates
    {
        Patrolling,
        Chasing,
        Attacking
    }

    [SerializeField] EnemyStates currentState;

    void Start()
    {

    }

    void Update()
    {
        //distance = Vector3.Distance(objectToChase.transform.position, gameObject.transform.position);

        Movement();

        if (EnemyHealth <= 0)
        {
            Destroy(Enemy);
        }
    }

   //void OnCollisionEnter(Collision collision)
   //{
   //    if (collision.gameObject.name == "Player")
   //    {
   //        //Attack
   //    }
   //}

    public void DeductHealth(int DamageAmount)
    {
        if (Enemy)
        {
            EnemyHealth -= DamageAmount;
        }
    }

    void Movement()
    {
        if (Vector3.Distance(transform.position, objectToChase.position) > 10f)
        {
            currentState = EnemyStates.Patrolling;
        }

        else
        {
            currentState = EnemyStates.Chasing;
        }

        if (currentState == EnemyStates.Patrolling)
        {
            if (destinations.Length > 0)
            {
                Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, destinations[currentDes].position, 5.0f * Time.deltaTime);

                if (Enemy.transform.position ==  destinations[currentDes].position)
                {
                    currentDes++;
                }
                if (currentDes >= destinations.Length)
                {
                    currentDes = 0;
                }
            }
        }

        if (currentState == EnemyStates.Chasing)
        {
           //RaycastHit hit;
           //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
           //{
           //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
           //    Debug.Log("Did Hit");
           //    Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, objectToChase.position, 5.0f * Time.deltaTime);
           //}
              
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, objectToChase.position, 5.0f * Time.deltaTime);

            if (Vector3.Distance(transform.position, objectToChase.position) <= 1f)
            {
                currentState = EnemyStates.Attacking;
            }
        }

        if(currentState == EnemyStates.Attacking)
        {
            StartCoroutine(Attacking());
        }
    }

    //void Attack()
    //{
    //    Debug.Log("Attacking");
    //    if (Attacked)
    //    {
    //        Attacked = false;
    //    }
    //}

    IEnumerator Attacking()
    {
        if(currentState == EnemyStates.Attacking)
        {
            Attacked = true;
        }

        if (Attacked == true)
        {
            Debug.Log("Attacking");
            Attacked = false;
        }
        yield return new WaitForSeconds(1.5f);
        Attacked = true;
    }
}