using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeTrap : MonoBehaviour
{
    public Text pressText;
    public bool button;
    public GameObject trap;
    private int counter;
    public int loops;
    public float waitTime;
    private float sequenceTime;
    private Animation anime;

    void Start()
    {
        anime = trap.GetComponent<Animation>();
        pressText.gameObject.SetActive(false);
        button = false;
        counter = loops;
        sequenceTime = 0;
    }

    private void Update()
    {
        if (button && Input.GetKeyDown(KeyCode.E))
        {
            counter = 0;
        }
        sequenceTime = sequenceTime + Time.deltaTime;

        if (counter < loops && sequenceTime >= waitTime)
        {
            Activated();
            sequenceTime = 0;
            counter++;
            Debug.Log("I work" + counter);
            
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
            button = true;
            print("press e");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            pressText.gameObject.SetActive(false);
            button = false;
        }   
    }

    public void Activated()
    {
        pressText.gameObject.SetActive(false);
        anime.Play();
    }

   
}
    