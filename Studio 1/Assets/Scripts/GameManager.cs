using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject winMenu;

    public bool pause = false;

    public bool questActivated;
    public bool questObjective1 = true;
    public bool questObjective2 = false;
    public bool questFinished = false;

    public Text quest1;
    public Text quest2;

    public enum State { running, pause, gameOver, gameWin}
    public State state;

    void Start()
    {
        state = State.running;
        quest1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.gameOver && state != State.gameWin)
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
        else if (state == State.gameWin)
        {
            GameWin();
        }
        else
        {
            StartCoroutine("GameOver");
        }
        if (questFinished == false)
        {
            if (questActivated == true)
            {
                if (questObjective1 == true)
                {
                    quest1.enabled = true;
                    quest2.text = "Get the toy for the maid";
                }
                if(questObjective2 == true)
                {
                    quest1.enabled = true;
                    quest2.text = "Return to the maid with the toy";
                }
            }
        }
        else if(questFinished == true)
        {
            state = State.gameWin;
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

    public void GameWin()
    {
        quest1.text = "";
        quest2.text = "";
        winMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5f);
        gameOverMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
