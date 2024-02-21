using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SystemRound : MonoBehaviour
{
    public int maxRounds = 20;
    private int currentRound = 1;

    public TextMeshProUGUI roundText;

    private void Start()
    {
        UpdateRoundText();
    }

    public void NextRound()
    {
        if (currentRound < maxRounds)
        {
            currentRound++;
            UpdateRoundText();
        }
    }

    private void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Round: " + currentRound + "/" + maxRounds;
        }
    }
}

