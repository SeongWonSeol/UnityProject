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
    }

    // Update is called once per frame
    void Update()
    {
        int deltaTimeAsInt = Mathf.RoundToInt(Time.deltaTime);

        IncreaseScore(deltaTimeAsInt);
        if (playerControllerScript.isRunning)
        {
            IncreaseScore(2 * deltaTimeAsInt);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
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
