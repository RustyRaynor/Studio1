using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health ;
    public float lastHitTime;
    public float healRate = 1f;
    public int trapDamage = 50;
    public float waitTime;
    public float hitTime;

    PlayerMovement player;


    void Start()
    {
        player = GetComponent<PlayerMovement>();
        hitTime = 0;
        health = 100;
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
    

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Trap")
        {
            if (Time.time - hitTime >= waitTime)
            {
                lastHitTime = Time.time;
                health -= trapDamage;
                hitTime = Time.time;
                Debug.Log("hit");
            }
        }
    }

}
