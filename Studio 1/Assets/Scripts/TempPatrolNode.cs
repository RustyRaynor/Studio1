using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPatrolNode : Node
{
    int position = 0;

    public override int UpdateNode(EnemyAbstract con)
    {
        con.anim.SetBool("walking", true);
        Debug.Log("Patrol");
        con.transform.position = Vector3.MoveTowards(con.transform.position, con.patrolPosition[position], con.speed * Time.deltaTime);
        con.transform.LookAt(con.patrolPosition[position]);

        if (con.transform.position == con.patrolPosition[position])
        {
            position++;
            if (position == con.patrolPosition.Length)
            {
                position = 0;
            }
        }
        return 1;
    }
}
