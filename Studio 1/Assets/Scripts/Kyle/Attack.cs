using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject player;
    float attackTime;
    bool attacking;
    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= 1.0f)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if(attack)
        {
            StartCoroutine(attackE());
        }
    }

    IEnumerator attackE()
    {
        if (!attacking)
        {
            attacking = true;
            Debug.Log("Attacking");
            //anim.setTrigger("Attack");
            yield return new WaitForSeconds(1.5f);
            attacking = false;
        }
    }
}
