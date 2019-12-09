using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectN : NodeBT
{
    public override int UpdateNode(Context context) //Detects if player can be seen or not
    {
        if (context.playerDetected == true)
        {
            if (context.publicCollider.isTrigger == false)
            {
                Debug.Log("Seen");
                Vector3 distance = context.publicCollider.transform.position - context.transform.position;

                float angle = Vector3.Angle(distance, context.transform.forward);

                if (angle <= context.fieldOfView * 0.5f)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(context.transform.position + context.transform.up * 1.4f, distance.normalized, out hit, context.sphere.radius))
                    {
                        if (hit.collider.tag == "Player")
                        {
                            return 2;
                        }
                    }
                    else if (Physics.Raycast(context.transform.position + context.transform.up, distance.normalized, out hit, context.sphere.radius))
                    {
                        if (hit.collider.tag == "Player")
                        {
                            return 2;
                        }
                    }
                }
            }
        }
        //context.anim.SetBool("detected", false);
        return 0;
    }
}
