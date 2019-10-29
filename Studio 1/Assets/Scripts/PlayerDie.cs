using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private int health = 100;
    private int damage = 50;

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "SpikeTrap")
        {
            health -= damage;
            if (health == 0)
            {
                health = 0;
                Dead();
            }
        }
        if (other.transform.tag == "Pendulum")
        {
            health -= damage;
            if (health == 0)
            {
                health = 0;
                Dead();
            }
            print("Health =" + health);
        }
    }

    private void Dead()
    {
        Destroy(gameObject);    
    }
}
