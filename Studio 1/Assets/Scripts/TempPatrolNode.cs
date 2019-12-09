using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPatrolNode : Node
{
    int position = 0;

    public override int UpdateNode(EnemyAbstract con)
    {
        con.anim.SetFloat("Speed", 1);
        con.speed = con.walkSpeed;

        //con.transform.position = Vector3.MoveTowards(con.transform.position, con.patrolPosition[position], con.speed * Time.deltaTime);
        //con.transform.LookAt(con.patrolPosition[position]);

        Vector3 distance = con.patrolPosition[position] - con.transform.position;
        Vector3 distanceLeft = distance.normalized;

        if (distance.magnitude <= distanceLeft.magnitude)
        {
            con.anim.SetBool("walking", false);
            if (Time.time - con.waitTime >= con.waitTimeRate)
            {
                position++;
                if (position == con.patrolPosition.Length)
                {
                    position = 0;
                }
            }
        }
        else
        {
            con.anim.SetBool("walking", true);
            con.Move(con.patrolPosition[position]);
            con.waitTime = Time.time;
        }
        return 1;
    }
}
