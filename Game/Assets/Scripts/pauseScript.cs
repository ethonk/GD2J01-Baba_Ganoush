using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()    //Public void so that we can access this resume func.
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;    //Time.timeScale = 1f meaning everything outside of pause menu is moving back to normal
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;    //Time.timeScale = 0f meaning everything outside of pause menu is time 0 meaning not moving
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu..");
        //SceneManager.LoadMenu("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();

    }
}
