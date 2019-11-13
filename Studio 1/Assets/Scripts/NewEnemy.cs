using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    public float speed;
    public int attackDamage;
    public int health;

    public int fieldOfView = 110;

    public SphereCollider sphere;

    public bool playerDetected = false;

    public Collider publicCollider;

    Selector sel1;
    Sequence seq1;
    Sequence seq2;
    AttackingNode attack1;
    TempPatrolNode patrol1;
    ChasingNode chase1;
    DetectionNode detectedBehavior;

    public Vector3[] patrolPosition = new Vector3[3];

    public GameObject player;

    Node node;

    private void Start()
    {
        sphere = GetComponent<SphereCollider>();
        sel1 = new Selector();
        seq1 = new Sequence();
        seq2 = new Sequence();
        attack1 = new AttackingNode();
        patrol1 = new TempPatrolNode();
        chase1 = new ChasingNode();
        detectedBehavior = new DetectionNode();

        sel1.nList.Add(seq1);
        sel1.nList.Add(patrol1);
        seq1.nList.Add(detectedBehavior);
        seq1.nList.Add(seq2);
        seq2.nList.Add(chase1);
        seq2.nList.Add(attack1);

        patrolPosition[0] = transform.position;

        node = sel1;
    }

    void Update()
    {
        node.UpdateNode(this);
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
