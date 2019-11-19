using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    Vector2 scroll;

    public GameObject player;
    public GameObject UI;

    [TextArea]
    public string content;

    public float interactDistance = 5f;
    float distance;

    bool interacting = false;

    public Text noteText;

    void Start()
    {
        UI.SetActive(false);
        noteText.text = content;
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
                    UI.SetActive(false);
                }
                else
                {
                    interacting = true;
                    UI.SetActive(true);
                }
            }
        }
        else
        {
            interacting = false;
            UI.SetActive(false);
        }
    }

    private void OnGUI()
    {
        if (interacting == false)
        {
            if (distance <= interactDistance)
            {
                GUI.TextArea(new Rect(Screen.height / 2, Screen.width / 2, 500, 500), "Press 'E' to read.");
            }
        }
    }
}