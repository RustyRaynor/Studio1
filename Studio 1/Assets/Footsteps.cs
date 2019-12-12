using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] footstep;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent <AudioSource>();    
    }

    public void Steps()
    {
        AudioClip footstep = GetSound();
        audio.PlayOneShot(footstep);
    }

    public AudioClip GetSound()
    {
        return footstep[Random.Range(0, footstep.Length)];
    }
}
