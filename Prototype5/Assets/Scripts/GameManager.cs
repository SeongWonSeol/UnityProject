using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeScoreText;
    public GameObject gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject titleText;
    public GameObject VolumeManager;
    public GameObject Pause;

    public bool isGameActive;

    private float spawnRate = 1.0f;
    private int score;

    private int lifeScore = 3;

    private bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Puased();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLifeScore(int lifeToAdd)
    {
        if (isGameActive)
        {
            lifeScore -= lifeToAdd;
            lifeScoreText.text = "Life: " + lifeScore;
            if (lifeScore <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        titleScreen.SetActive(false);
        titleText.SetActive(false);
        scoreText.gameObject.SetActive(true);
        lifeScoreText.gameObject.SetActive(true);
        VolumeManager.SetActive(false);
        UpdateScore(0);

        StartCoroutine(SpawnTarget());
    }

    public void Puased()
    {
        if (!isGamePaused)
        {
            isGamePaused = true;
            Pause.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            isGamePaused = false;
            Pause.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
