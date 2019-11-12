using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedBehavior : MonoBehaviour
{
    public int fieldOfView;

    Animator anim;
    SphereCollider sphere;

    bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sphere = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetected == true)
        {
            anim.SetBool("detected", true);
        }
        else
        {
            anim.SetBool("detected", false);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 distance = collision.transform.position - transform.position;

            float angle = Vector3.Angle(distance, transform.forward);

            if(angle <= fieldOfView * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.up * 1.4f, distance.normalized, out hit, sphere.radius))
                {
                    if (hit.collider.tag == "Player")
                    {
                        playerDetected = true;
                    }
                    else
                    {
                        playerDetected = false;
                    }
                }
                else if (Physics.Raycast(transform.position + transform.up, distance.normalized, out hit, sphere.radius))
                {
                    if (hit.collider.tag == "Player")
                    {
                        playerDetected = true;
                    }
                    else
                    {
                        playerDetected = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;
        }
    }
}
