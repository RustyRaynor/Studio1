using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    State state;
    State currentState;
    public int battery = 0;

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject options;
    public GameObject help;
    public GameObject game;

    private void Start()
    {
        state = new MainMenuState();
        state.prevState = state;
    }

    private void Update()
    {
        state.UpdateState(this);
    }

    public void PauseMenu()
    {
        currentState = state;
        state = new PauseState();
        state.prevState = currentState;
    }
    public void MainMenu()
    {
        currentState = state;
        state = new MainMenuState();
        state.prevState = currentState;
    }
    public void Option()
    {
        currentState = state;
        state = new Options();
        state.prevState = currentState;
    }
    public void Helps()
    {
        currentState = state;
        state = new Help();
        state.prevState = currentState;
    }
    public void Game()
    {
        currentState = state;
        state = new GamePlayState();
        state.prevState = currentState;
    }

    public void Exit()
    {
        state = state.prevState;
    }
}
