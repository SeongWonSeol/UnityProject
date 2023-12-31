using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    private int score = 0;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreText();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }

    public void IncreaseScore()
    {
        if (playerControllerScript.isRunning && !playerControllerScript.gameOver)
        {
            score += 20;
        }
        else if (!playerControllerScript.gameOver)
        {
            score += 10;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
