using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject highScoreField;

    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public static int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        instance.highscore = PlayerPrefs.GetInt("highscore", 0);
        instance.scoreText.SetText(score.ToString() + " POINTS");
        instance.highscoreText.SetText("HIGHSCORE: " + highscore.ToString());
    }

    public void AddPoint(int x)
    {
        score += x;
        instance.scoreText.SetText(score.ToString() + " POINTS");
        if(highscore < score) 
        {
            PlayerPrefs.SetInt("highscore", score);
            highScoreField.SetActive(true); 
        }
        
    }
}
