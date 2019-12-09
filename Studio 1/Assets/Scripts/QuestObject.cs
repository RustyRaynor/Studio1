using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour
{
    public GameObject player;

    GameManager gameManager;
    public GameObject InteractingUI;

    public Text quest2;

    bool playerIn = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = player.GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn == true)
        {
            if (gameManager.questActivated == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameManager.questObjective2 = true;
                    gameManager.questObjective1 = false;
                    InteractingUI.SetActive(false);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameManager.questActivated == true)
            {
                InteractingUI.SetActive(true);
                playerIn = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
            InteractingUI.SetActive(false);
        }
    }
}
