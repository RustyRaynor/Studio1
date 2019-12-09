using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBT : EnemyAbstract
{
    Selector sel1;
    Selector sel2;

    Sequence seq1;
    Sequence seq2;
    Sequence seq3;

    DetectionNode detectionNode;
    SoundDetectionNode sound;
    AttackingNode attack;
    ChasingNode chase;
    TempPatrolNode patrol;
    DyingCheckNode dyingCheckNode;
    DeathNode deathNode;
    LastKnownCheckNode knownCheckNode;
    GoToLastKnown goToLastKnown;

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
        seq2 = new Sequence();
        seq3 = new Sequence();
        detectionNode = new DetectionNode();
        sound = new SoundDetectionNode();
        attack = new AttackingNode();
        chase = new ChasingNode();
        patrol = new TempPatrolNode();
        dyingCheckNode = new DyingCheckNode();
        deathNode = new DeathNode();
        knownCheckNode = new LastKnownCheckNode();
        goToLastKnown = new GoToLastKnown();

        sel1.nList.Add(seq1);
        sel1.nList.Add(seq2);
        sel1.nList.Add(seq3);
        sel1.nList.Add(patrol);

        seq1.nList.Add(dyingCheckNode);
        seq1.nList.Add(deathNode);

        seq2.nList.Add(sel2);
        seq2.nList.Add(chase);
        seq2.nList.Add(attack);

        seq3.nList.Add(knownCheckNode);
        seq3.nList.Add(goToLastKnown);

        sel2.nList.Add(detectionNode);
        sel2.nList.Add(sound);
        

        patrolPosition[0] = transform.position;

        node = sel1;
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
        node.UpdateNode(this);
    }
}
