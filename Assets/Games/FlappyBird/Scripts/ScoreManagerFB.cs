using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerFB : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] TMP_Text _highScoreText;
    public static int scoreFB;
    int highscoreFB;
    void Start()
    {
        scoreFB = 0;
    }


    void Update()
    {
        highscoreFB = scoreFB;
        _scoreText.text = highscoreFB.ToString();
        if (PlayerPrefs.GetInt("scoreFB") <= highscoreFB)
        {
            PlayerPrefs.SetInt("scoreFB", highscoreFB);
        }
        _highScoreText.text = PlayerPrefs.GetInt("scoreFB").ToString();
    }
}

