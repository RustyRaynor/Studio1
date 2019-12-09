using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNode : NodeBT
{
    public int currentDes;

    public override int UpdateNode(Context con)
    {
        Debug.Log("Patrolling");
        con.Seek(con.positions[currentDes]);
        con.transform.LookAt(con.positions[currentDes]);
        con.anim.SetBool("isWalking", true);

        if (con.positions.Length > 0)
        {
            if (con.transform.position == con.positions[currentDes])
            {
                currentDes++;
            }
            if (currentDes >= con.positions.Length)
            {
               currentDes = 0;
            }
        }
        return 1;      
    }
}
