using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool pause = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        if(pause != true)
        {
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause == true)
            {
                pause = false;
            }
            else
            {
                pause = true;
            }
        }
    }

    public void Resume()
    {
        pause = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
