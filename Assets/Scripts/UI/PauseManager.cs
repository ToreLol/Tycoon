using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    //Public Variables
    public GameObject pausePanel, playerUI;

    //Private Variables
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        CursorState(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseInput();
    }

    //Use Input Function
    void PauseInput()
    {
        //If keycode is pressed
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //Pause Game Function
    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        playerUI.SetActive(false);
        CursorState(true);
        Time.timeScale = 0f;
    }

    //Resume Game Function
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        playerUI.SetActive(true);
        CursorState(false);
        Time.timeScale = 1f;
    }

    //Activate & Deactivate Cursor
    public void CursorState(bool _state)
    {
        Cursor.visible = _state;
        if(_state)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
