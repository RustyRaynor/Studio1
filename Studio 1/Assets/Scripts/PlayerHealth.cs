using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health ;
    public float lastHitTime;
    public float healRate = 1f;

    PlayerMovement player;
    public GameObject panel;
    Image image;
    public Color tempColor;
    

    void Start()
    {
        player = GetComponent<PlayerMovement>();
<<<<<<< HEAD
        hitTime = 0;
        health = 100;
=======
        image = panel.GetComponent<Image>();
        tempColor = image.color;
>>>>>>> 4d9d41c8bfa8b2a7ff9a772dcc0d9ed05f2fd861
    }

    // Update is called once per frame
    void Update()
    {
        if (player.state == PlayerMovement.State.alive)
        {
            DamagePlayer();
            if (Time.time - lastHitTime >= healRate)
            {
                StartCoroutine("Heal");
            }
        }
        image.color = tempColor;
        tempColor.a = (100f - health) / 100f;
    }

    IEnumerator Heal()
    {
        if(health < 100)
        {
           //    health += 1;
        }
        yield return new WaitForSeconds(1f);
    }

    void DamagePlayer()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            lastHitTime = Time.time;
            health -= 20;
        }
    }
}
