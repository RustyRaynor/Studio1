using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    public Transform bleed;
    // Start is called before the first frame update
    void Start()
    {
        bleed.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Traps")
        {
            bleed.GetComponent<ParticleSystem>().enableEmission = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
