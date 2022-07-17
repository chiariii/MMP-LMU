using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == true)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
    }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

    }

    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

    }

    public void LoadMenu()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quit");	
        Application.Quit();
    }

}

