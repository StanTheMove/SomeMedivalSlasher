using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public class HighScoreDisplay : MonoBehaviour
    {
        public TextMeshProUGUI highScoreText;
        private ScoreManager scoreManager;

        void Start()
        {
            UpdateHighScoreText();
        }

        void UpdateHighScoreText()
        {
            if (scoreManager != null)
            {
                highScoreText.text = "HIGH SCORE: " + scoreManager.highScore.ToString();
            }
        }
    }
}

