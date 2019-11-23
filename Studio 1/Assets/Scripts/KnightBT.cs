using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBT : EnemyAbstract
{
    Selector sel1;
    Selector sel2;

    Sequence seq1;

    DetectionNode detectionNode;
    SoundDetectionNode sound;
    AttackingNode attack;
    ChasingNode chase;
    TempPatrolNode patrol;

    // Start is called before the first frame update
    void Start()
    {
        attackRate = 3;

        playerCode = player.GetComponent<PlayerMovement>();

        anim = GetComponent<Animator>();
        sphere = GetComponent<SphereCollider>();

        sel1 = new Selector();
        sel2 = new Selector();
        seq1 = new Sequence();
        detectionNode = new DetectionNode();
        sound = new SoundDetectionNode();
        attack = new AttackingNode();
        chase = new ChasingNode();
        patrol = new TempPatrolNode();

        sel1.nList.Add(seq1);
        sel1.nList.Add(patrol);

        seq1.nList.Add(sel2);
        seq1.nList.Add(chase);
        seq1.nList.Add(attack);

        sel2.nList.Add(detectionNode);
        sel2.nList.Add(sound);
        

        patrolPosition[0] = transform.position;

        node = sel1;
    }

    // Update is called once per frame
    void Update()
    {
        node.UpdateNode(this);
    }
}
