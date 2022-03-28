using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerRN : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _highScoreText;
    public static int scoreRN;
    int highscoreRN;
    void Start()
    {
        scoreRN = 0;
    }


    void Update()
    {
        highscoreRN = scoreRN;
        _scoreText.text = "SCORE: " + highscoreRN.ToString();
        if (PlayerPrefs.GetInt("scoreRN") <= highscoreRN)
        {
            PlayerPrefs.SetInt("scoreRN", highscoreRN);
        }
        _highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("scoreRN").ToString();
    }
}
