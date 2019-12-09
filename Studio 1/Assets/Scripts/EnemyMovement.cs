using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Node
{
   // public Vector3 distance;
   // public Vector3 footstep;
   //
   // public override int UpdateNode(EnemyAbstract man)
   // {
   //     Debug.Log("patrol");
   //     distance = man.patrolPosition[man.index] - man.transform.position;
   //     footstep = distance.normalized * man.speed * Time.deltaTime;
   //     man.transform.position = man.transform.position + footstep;
   //
   //     if (distance.magnitude <= footstep.magnitude)
   //     {
   //         man.index++;
   //         if (man.index == man.patrolPosition.Length)
   //         {
   //             man.index = 0;
   //         }
   //         
   //     }
   //     return 0;
   // }
}
