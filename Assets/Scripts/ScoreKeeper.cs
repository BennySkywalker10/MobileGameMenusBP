using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;

    public Text highscoreText;

    private string SCORE = "HighScore";

    public int actualScore;
    // Start is called before the first frame update
    void Start()
    {
        actualScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + actualScore;
        highscoreText.text = "HighScore: " + PlayerPrefs.GetInt(SCORE);
    }

    public void AddPoint()
    {
        actualScore ++;

        if (PlayerPrefs.GetInt(SCORE) <= actualScore)
        {
            PlayerPrefs.SetInt(SCORE, actualScore);
        }

        highscoreText.text = "HighScore: " + PlayerPrefs.GetInt(SCORE);
    }

}
