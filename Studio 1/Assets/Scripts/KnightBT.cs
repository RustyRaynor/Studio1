using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBT : EnemyAbstract
{
    Selector sel1;
    Sequence seq1;
    Sequence seq2;
    AttackingNode attack1;
    TempPatrolNode patrol1;
    ChasingNode chase1;
    DetectionNode detectedBehavior;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

    // Update is called once per frame
    void Update()
    {
        node.UpdateNode(this);
    }
}
