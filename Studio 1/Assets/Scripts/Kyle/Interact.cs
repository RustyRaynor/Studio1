using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public bool isInteractable = false;

    public string name;
    public string[] sentences;
    int line = 0;
    public Text convo;
    public Text nameText;

    public GameObject UI;
    public GameObject button;

    bool interacted = false;

    public float interactDistance = 5f;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        nameText.text = name;
        convo.text = sentences[line];
    }        

    void Update()
    {
        ////Checks if the player is in the collider and also if the key is pressed.
        //if (isInteractable && Input.GetKeyDown(KeyCode.F))
        //{
        //    //personalized code can go in here when activated.
        //    interacted = true;
        //}
        //else
        //{
        //    interacted = false;
        //}
        if(isInteractable == true)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }

        if (convo.text == sentences[line])
        {
            button.SetActive(true);
        }
    }

    /// <summary>
    /// Is called when there is an object that enters the collider's borders.
    /// </summary>
    

    private void OnTriggerEnter(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if (other.gameObject.name == "Player")
        {
            //turns on interactivity 
            isInteractable = true;
        }
    }
    /// <summary>
    /// Is called when there is an object that leaves the collider's borders.
    /// </summary>

    private void OnTriggerExit(Collider other)
    {
        //compares the tag of the object exiting this collider.
        if (other.gameObject.name == "Player")
        {
            //turns off interactivity
                isInteractable = false;
                interacted = false;
        }
    }

    public void Next()
    {
        button.SetActive(false);

        if (isInteractable == true)
        {
            if (line < sentences.Length - 1)
            {
                {
                    line++;
                    convo.text = "";
                    //convo.text = sentences[line];
                    //for (int i = 0; i < sentences.Length; i++)
                    //{
                    //    convo.text = convo.text + sentences[i];
                    //    timeRate = 1.0f;
                    //}
                    StartCoroutine(Separate());
                }
            }
            else
            {
                isInteractable = false;
                UI.SetActive(false);
                line = 0;
                convo.text = sentences[line];
                button.SetActive(false);
            }
        }

        if (convo.text == sentences[line])
        {
            button.SetActive(true);
        }
    }

    IEnumerator Separate()
    {
        foreach (char letter in sentences[line].ToCharArray())
        {
            convo.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnGUI()
    {
        if (isInteractable == true && interacted == false)
        {
                GUI.TextArea(new Rect(Screen.height / 2, Screen.width / 2, 500, 500), "Press 'E' to read.");
        }
    }
}
