using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public List<GameObject> traps;

    Traps trapCode;

    Animator anim;

    public GameObject InteractingUI;

    bool playerIn = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("on");
                for (int i = 0; i < traps.Count; i++)
                {
                    trapCode = traps[i].GetComponent<Traps>();
                    if (trapCode.on == false)
                    {
                        trapCode.on = true;
                    }
                    else
                    {
                        trapCode.on = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractingUI.SetActive(true);
            playerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractingUI.SetActive(false);
            playerIn = false;
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < traps.Count; i++)
        {
            Gizmos.DrawLine(transform.position, traps[i].transform.position);
        }
    }
}
