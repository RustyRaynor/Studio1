using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogEffect : MonoBehaviour
{
    float timeRate = 1.0f;
    float timesincelastword;
    public string word;

    public void Start()
    {
        //StartCoroutine(Separate());
    }

    public void Update()
    {
        Next();
    }

    public void Next()
    {
        timeRate -= Time.deltaTime;
        if (timeRate <= 0)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Debug.Log(word[i]);
                timeRate = 1.0f;
            }
        }
    }

   // IEnumerator Separate()
   // {
   //     for(int i = 0; i < word.Length; i++)
   //     {
   //         Debug.Log(word[i]);
   //         textUI.text = textUI.text + word[i];
   //         timeRate = 1.0f;
   //         yield return new WaitForSeconds(1.0f);
   //     }
   // }
}
