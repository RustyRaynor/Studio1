using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNode : NodeBT
{
    public Vector3[] positions;
    public int currentDes;

    public override int UpdateNode(Context con)
    {
        con.Seek(positions[currentDes]);

        if (positions.Length > 0)
        {
            if (con.transform.position == positions[currentDes])
            {
                currentDes++;
            }
            if (currentDes >= positions.Length)
            {
               currentDes = 0;
            }
        }
        return 1;
    }
}
