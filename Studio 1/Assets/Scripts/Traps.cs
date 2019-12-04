using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    PlayerHealth player;
    EnemyAbstract enemy;

    Animator anim;

    public float speed;
    public bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(on == true)
        {
            anim.SetBool("on", true);
            anim.speed = speed;
        }
        else
        {
            anim.SetBool("on", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger == false)
        {
            if (other.tag == "Player")
            {
                player = other.GetComponent<PlayerHealth>();
                player.health -= 20;
                player.lastHitTime = Time.time;
            }
            else if (other.tag == "Enemy")
            {
                enemy = other.GetComponent<EnemyAbstract>();
                enemy.health -= 100;
                Debug.Log("Hit");
            }
        }
    }
}
