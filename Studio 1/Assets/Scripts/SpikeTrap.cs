using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeTrap : MonoBehaviour
{
    public Text pressText;
    //public bool button;
    public GameObject trap;
    private Animation anime;

    void Start()
    {
        anime = trap.GetComponent<Animation>();
        pressText.gameObject.SetActive(false);
        //button = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Activated();
        }
    }
    public void ButtonPressed()
    {
        pressText.gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            pressText.gameObject.SetActive(true);
            //button = true;
            print("press e");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            pressText.gameObject.SetActive(false);
            //button = false;
        }   
    }

    public void Activated()
    {
        pressText.gameObject.SetActive(false);
        //button = true;
        anime.Play();
    }

    

}
    