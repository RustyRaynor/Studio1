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

        detection = new DetectN();
        sdetection = new SDectN();
        patrol = new PatrolNode();
        attack = new AttackN();
        pursue = new PursueN();
        death = new DeathN();

        selector1.nodeList.Add(sequence1);
        selector1.nodeList.Add(sequence2);

        selector1.nodeList.Add(patrol);

        sequence1.nodeList.Add(death);
        
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
