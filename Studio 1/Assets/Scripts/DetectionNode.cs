using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionNode : Node
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    public override int UpdateNode(EnemyAbstract con)
    {
        if (con.playerDetected == true)
        {
            Debug.Log("Seen");
            Vector3 distance = con.publicCollider.transform.position - con.transform.position;

            float angle = Vector3.Angle(distance, con.transform.forward);

            if (angle <= con.fieldOfView * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(con.transform.position + con.transform.up * 1.4f, distance.normalized, out hit, con.sphere.radius))
                {
                    if (hit.collider.tag == "Player")
                    {
                        Debug.Log("Success");
                        con.anim.SetBool("detected", true);
                        return 2;
                    }
                }
                else if (Physics.Raycast(con.transform.position + con.transform.up, distance.normalized, out hit, con.sphere.radius))
                {
                    if (hit.collider.tag == "Player")
                    {
                        con.anim.SetBool("detected", true);
                        return 2;
                    }
                }
            }
        }
        Debug.Log("Fail");
        con.anim.SetBool("detected", false);
        return 0;
    }
}
