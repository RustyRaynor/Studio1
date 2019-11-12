using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy
{
    protected float speed;
    protected int attackDamage;
    public int health;

    public Vector3[] patrolPosition = new Vector3[3];

    Node node;

   void Update()
    {
        node.UpdateBehavior(this);
    }
}
