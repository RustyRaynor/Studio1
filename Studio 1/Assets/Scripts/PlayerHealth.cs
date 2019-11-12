using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public float lastHitTime;
    public float healRate = 1f;

    PlayerMovement player;


    void Start()
    {
        player = GetComponent<PlayerMovement>();
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
    }

    IEnumerator Heal()
    {
        if(health < 100)
        {
            health += 1;
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
