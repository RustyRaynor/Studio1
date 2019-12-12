using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   public GameObject mainMenu;
   public GameObject credits;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void CreditsBack()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
