using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPatrolNode : Node
{
    int position = 0;

    public override int UpdateNode(NewEnemy con)
    {
        Debug.Log("Patrol");
        con.transform.position = Vector3.MoveTowards(con.transform.position, con.patrolPosition[position], con.speed * Time.deltaTime);

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
