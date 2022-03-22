using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _highScoreText;
    public static int score;
    int highscore;
    void Start()
    {
        score = 0;
    }


    void Update()
    {
        highscore = score;
        _scoreText.text = "SCORE: " + highscore.ToString();
        if (PlayerPrefs.GetInt("score") <= highscore)
        {
            PlayerPrefs.SetInt("score", highscore);
        }
        _highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("score").ToString();
    }
}
