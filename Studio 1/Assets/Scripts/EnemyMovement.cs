using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class EnemyMovement : Node
{
    public float speed = 60;
    public Vector3 distance;
    public Vector3 footstep;

    public override void UpdateScreen(Manager man)
    {
        distance = man.patrol[man.index] - man.transform.position;
        footstep = distance.normalized * speed * Time.deltaTime;
        man.transform.position = man.transform.position + footstep;

        if (distance.magnitude <= footstep.magnitude)
        {
            man.index++;
            if (man.index == man.patrol.Length)
            {
                man.index = 0;
            }
        }
    }
}*/
