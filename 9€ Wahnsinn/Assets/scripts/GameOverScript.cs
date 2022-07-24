using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverScreen;

    public void endGame()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
        
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ScoreManager.score = 0;
        SceneManager.LoadScene(1);
    }
}
