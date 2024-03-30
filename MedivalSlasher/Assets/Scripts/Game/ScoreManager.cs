using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    public int highScore = 0;
    private const string highScoreKey = "HighScore";

    private void Awake()
    {
        LoadHighScore();
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        UpdateHighScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();

        if (score > highScore)
        {
            highScore = score;
            UpdateHighScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateHighScoreUI()
    {
        highScoreText.text = "High Score: " + highScore;
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
