using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    public void Start()
    {
        Time.timeScale = 1f;
    }

    public void playGame()
    {
        SceneManager.LoadScene("choosemaze");
    }

    public void mazeA()
    {
        SceneManager.LoadScene("gamescene");
    }

    public void mazeB()
    {
        SceneManager.LoadScene("gamescene2");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
        
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ChooseMaze()
    {
        SceneManager.LoadScene("choosemaze");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            quitGame();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
}
