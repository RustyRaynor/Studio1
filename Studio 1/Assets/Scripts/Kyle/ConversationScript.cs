using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationScript : MonoBehaviour
{
    public string name;
    public string[] sentences;
    int line = 0;
    public Text convo;
    public Text nameText;

    public GameObject player;
    public GameObject UI;
    public GameObject button;

    public float interactDistance = 5f;
    float distance;

    bool interacting = false;

    // Start is called before the first frame update
    void Start()
    { 
        UI.SetActive(false);
        nameText.text = name;
        convo.text = sentences[line];
    }

    // Update is called once per frame
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
                    UI.SetActive(true);
                }
            }
        }
        else
        {
            interacting = false;
            UI.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Next();
        //}

        if (convo.text == sentences[line])
        {
            button.SetActive(true);
        }
    }

    public void Next()
    {
        button.SetActive(false);

        if (interacting == true)
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
                interacting = false;
                UI.SetActive(false);
                line = 0;
                convo.text = sentences[line];
                button.SetActive(false);
            }
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
        if (interacting == false)
        {
            if (distance <= interactDistance)
            {
                GUI.TextArea(new Rect(Screen.height / 2, Screen.width / 2, 500, 500), "Press 'E' to read.");
            }
        }
    }
}
