using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public bool pause = false;

    public enum State { running, pause, gameOver}
    public State state;

    void Start()
    {
        state = State.running;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.gameOver)
        {
            Pause();
            if (state == State.running)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (state == State.pause)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            StartCoroutine("GameOver");
        } 
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(state != GameManager.State.pause)
            {
                state = GameManager.State.pause;
            }
            else
            {
                state = GameManager.State.running;
            }
        }
    }

    public void Resume()
    {
        state = State.running;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3f);
        gameOverMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
