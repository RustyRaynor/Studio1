using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    public float delayTime;
    private Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (true)
        {
            anim.Play();
            yield return new WaitForSeconds(5f);
        }
    }
}
    