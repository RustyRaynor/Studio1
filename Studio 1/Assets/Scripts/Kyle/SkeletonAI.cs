using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : Context
{
    SelectorN selector1;
    SelectorN selector2;
    SequenceN sequence1;
    SequenceN sequence2;

    DetectN detection;
    SDectN sdetection;
    PatrolNode patrol;
    AttackN attack;
    PursueN pursue;
    DeathN death;

    void Start()
    {
        selector1 = new SelectorN();
        selector2 = new SelectorN();
        sequence1 = new SequenceN();
        sequence2 = new SequenceN();

        detection = new DetectN(); //Checks whether Player can be seen or not
        sdetection = new SDectN(); //Checks whether Player can be heard or not
        patrol = new PatrolNode(); //Patrols points with the seek steering behaviour
        attack = new AttackN(); //Attacks the player if the enemy is within striking range
        pursue = new PursueN(); //Chases the player using pursue steering behavior
        death = new DeathN(); //Dies if health is 0 s

        selector1.nodeList.Add(death);

        selector1.nodeList.Add(sequence2);

        selector1.nodeList.Add(patrol);

        //sequence1.nodeList.Add(death);

        

        sequence2.nodeList.Add(selector2);
        sequence2.nodeList.Add(pursue);
        sequence2.nodeList.Add(attack);

        selector2.nodeList.Add(detection);
        selector2.nodeList.Add(sdetection);

        nodebt = selector1;
    }

    void Update()
    {
        Death();
        nodebt.UpdateNode(this);
    }
}
