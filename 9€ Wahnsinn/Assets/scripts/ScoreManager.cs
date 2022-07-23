using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI highscoreText;

    public static int score = 0;
    //public static int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        //highscoreText = GetComponent<TextMeshProUGUI>();
        //scoreText.text = score.ToString() + " POINTS";
        //highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(score.ToString() + " POINTS");
        //highscoreText.SetText("HIGHSCORE: " + highscore.ToString());
    }
}
