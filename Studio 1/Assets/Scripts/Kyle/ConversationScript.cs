using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationScript : MonoBehaviour
{
    public string name;
    public string[] sentences;
    int line = 0;
    public int secondQuestLine;
    public Text convo;
    public Text nameText;

    public GameObject InteractingUI;
    public GameObject GameMan;

    GameManager gameManager;
    Coroutine x;

    bool playerIn = false;

    public GameObject UI;

    bool interacting = false;
    public bool questGiver;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        nameText.text = name;
        gameManager = GameMan.GetComponent<GameManager>();
        convo.text = sentences[line];
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UI.SetActive(true);
                interacting = true;
                playerIn = false;
                convo.text = "";
                if (gameManager.questObjective1 == false)
                {
                    line = secondQuestLine;
                }
                x = StartCoroutine(Seperate());
            }
        }
        else
        {
            InteractingUI.SetActive(false);
        }

        if (interacting == true)
        {
            if (questGiver == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StopCoroutine(x);

                    if (gameManager.questObjective1 == true)
                    {
                        if (line < secondQuestLine - 1)
                        {
                            
                                line++;
                                convo.text = "";
                                x = StartCoroutine(Seperate());
                        }
                        else
                        {
                            UI.SetActive(false);
                            interacting = false;
                            line = secondQuestLine - 1;
                            gameManager.questActivated = true;
                        }
                    }
                    else
                    {
                        if (line < sentences.Length - 1)
                        {
                              line++;
                              convo.text = "";
                              x = StartCoroutine(Seperate());
                        }
                        else
                        {
                            UI.SetActive(false);
                            interacting = false;
                            line = secondQuestLine - 1;
                            gameManager.questFinished = true;
                        }
                    }
                }
            }
            else
            {
                if (line < sentences.Length - 1)
                {

                    line++;
                    convo.text = "";
                    x = StartCoroutine(Seperate());

                }
                else
                {
                    UI.SetActive(false);
                    interacting = false;
                    line = 0;
                }
            }
        }
    }

        IEnumerator Seperate()
        {
            foreach (char letter in sentences[line].ToCharArray())
            {
                convo.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                InteractingUI.SetActive(true);
                playerIn = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                playerIn = false;
                UI.SetActive(false);
            }
        }
}