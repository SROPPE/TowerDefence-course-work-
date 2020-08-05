using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    [SerializeField] GameObject pauseMenu;
  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        
        IsPaused = true;
        Time.timeScale = 0f;
        this.pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        this.pauseMenu.SetActive(false);
  
    }
    public void LoadMenu()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
 
        Application.Quit();
    }
}
