using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverScreen;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endGame()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ScoreManager.score = 0;
        // SoundManager.Instance.Stop();
        SceneManager.LoadScene(1);
    }
}
