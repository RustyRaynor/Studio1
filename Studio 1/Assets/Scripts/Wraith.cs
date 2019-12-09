using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : EnemyAbstract
{
    Selector selector;
    Sequence sequence;
    AttackingNode attack;
    ChasingNode chase;
    TempPatrolNode patrol;
    DetectionNode detect;
    SoundDetectionNode sound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerCode = player.GetComponent<PlayerMovement>();
        sphere = GetComponent<SphereCollider>();
        

        selector = new Selector();
        sequence = new Sequence();
        chase = new ChasingNode();
        patrol = new TempPatrolNode();
        attack = new AttackingNode();
        detect = new DetectionNode();
        sound = new SoundDetectionNode();
        selector.nList.Add(sequence);
        selector.nList.Add(patrol);
        sequence.nList.Add(detect);
        sequence.nList.Add(chase);
        sequence.nList.Add(attack);

        patrolPosition[0] = transform.position;



        node = selector;
    }

    void Update()
    {
        node.UpdateNode(this);
    }
   
}
