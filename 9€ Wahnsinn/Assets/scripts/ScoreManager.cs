using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject hcingo;

    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public static int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance.highscore = PlayerPrefs.GetInt("highscore", 0);
        //scoreText = GetComponent<TextMeshProUGUI>();
        //highscoreText = GetComponent<TextMeshProUGUI>();

        //scoreText.text = score.ToString() + " POINTS";
        //highscoreText.text = "HIGHSCORE: " + highscore.ToString();

        instance.scoreText.SetText(score.ToString() + " POINTS");
        instance.highscoreText.SetText("HIGHSCORE: " + highscore.ToString());
    }

    // Update is called once per frame
    /*void Update()
    {
        scoreText.SetText(score.ToString() + " POINTS");
        //highscoreText.SetText("HIGHSCORE: " + highscore.ToString());
        
    }
    */

    public void AddPoint(int x)
    {
        score += x;
        instance.scoreText.SetText(score.ToString() + " POINTS");
        if(highscore < score) 
        {
            PlayerPrefs.SetInt("highscore", score);
            hcingo.SetActive(true); //shows highscore in gameoverscreen
        }
        
    }
}
