using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEndGame : MonoBehaviour
{
    public PlayerHealth cube;
    public float gameOverDelay = 6f;
    public TextMeshProUGUI gameOverText;
    public ScoreManager scoreManager;

    private bool gameEnded = false;

    void Update()
    {
        if (cube == null && !gameEnded)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        gameEnded = true;

        gameOverText.text = "GAME OVER";

        scoreManager.SaveHighScore();

        Invoke("ReturnToMainMenu", gameOverDelay);
        Time.timeScale = 0f;
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
