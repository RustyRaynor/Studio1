using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Image noteImage;

    public GameObject player;

    public float interactDistance = 5f;
    float distance;

    bool interacting = false;

    void Start()
    {
        noteImage.enabled = false;
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (distance <= interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (interacting)
                {
                    interacting = false;
                }
                else
                {
                    interacting = true;
                }
            }
        }
        else
        {
            interacting = false;
            noteImage.enabled = false;
        }
    }

    void OnGUI()
    {
        if (interacting)
        {
            noteImage.enabled = true;
        }
        else if (distance <= interactDistance)
        {
            GUI.TextArea(new Rect(Screen.height / 2, Screen.width / 2, 500, 500), "Press 'E' to read.");
        }
    }
}