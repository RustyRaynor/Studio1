using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth healthComponent = other.gameObject.GetComponent<PlayerHealth>();
            healthComponent.health -= damage;
        }
    }
}
