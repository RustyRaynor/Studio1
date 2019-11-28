using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
   // public enum result
   // {
   //     Failure,
   //     Running,
   //     Success
   // }

    public int state;

   // public result curResult;

    public List<Node> nList = new List<Node>();

    public virtual int UpdateNode(EnemyAbstract con)
    {
        return 0;
    }

    protected void Seek(EnemyAbstract con, Vector3 target)
    {
        con.desiredVelocity = (target - con.transform.position).normalized * con.maxVelocity;
        Vector3 turn = con.desiredVelocity - con.velocity;
        float distance = con.desiredVelocity.magnitude;
        if (distance < con.slowingR)
        {
            con.desiredVelocity = con.desiredVelocity.normalized * con.maxVelocity * (distance / con.slowingR);
        }
        else
        {
            con.desiredVelocity = con.desiredVelocity.normalized * con.maxVelocity;
        }
        turn = Vector3.ClampMagnitude(turn, con.maxForce);
        turn = turn / con.mass;
        con.velocity = Vector3.ClampMagnitude(con.velocity + turn * Time.deltaTime, con.maxVelocity);
        con.transform.position += con.velocity * Time.deltaTime;
        con.transform.LookAt(target);
    }
}