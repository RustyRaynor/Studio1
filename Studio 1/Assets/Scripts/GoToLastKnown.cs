using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLastKnown : Node
{
    public override int UpdateNode(EnemyAbstract con)
    {
        con.speed = con.walkSpeed;
        con.anim.SetFloat("Speed", 1);

        Vector3 distance = con.lastKnownLocation - con.transform.position;
        Vector3 distanceLeft = distance.normalized;

        if (distance.magnitude <= distanceLeft.magnitude)
        {
            con.anim.SetBool("walking", false);
            if (Time.time - con.waitTime >= con.waitTimeRate)
            {
                con.lastKnown = false;
            }
            return 2;
        }
        else
        {
            con.Move(con.lastKnownLocation);
            con.anim.SetBool("walking", true);
            con.waitTime = Time.time;
        }
        return 1;
    }
}
