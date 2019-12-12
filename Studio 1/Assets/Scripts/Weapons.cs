using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth healthComponent = other.gameObject.GetComponent<PlayerHealth>();
            healthComponent.lastHitTime = Time.time;
            healthComponent.health -= damage;
        }
    }
}
