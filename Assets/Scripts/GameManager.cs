using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Health;
    [SerializeField]
    private TextMeshProUGUI TimerText;
    public GameObject GameOverPanel;

    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 9;
    private float spawnPosZ = 7;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    int minutes;

    int seconds;

    int miliseconds;


    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        if (!MainManager.Instance.isGameOver)
        {
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }

    void Update()
    {


        Timer();
        Health.text = $"Health: {MainManager.Instance.health}/10";
        TimerText.text = string.Format(MainManager.Instance.timeFormat, minutes, seconds, miliseconds);
        if (MainManager.Instance.health <= 0)
        {
            GameOver();
        }
        if (MainManager.Instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MainManager.Instance.health = 10;
                MainManager.Instance.isGameOver = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void Timer()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60);
        seconds = (int)(Time.timeSinceLevelLoad % 60);
        miliseconds = Mathf.RoundToInt((Time.timeSinceLevelLoad - minutes * 60 - seconds) * 100);
    }

    void GameOver()
    {
        if (seconds > MainManager.Instance.BestSeconds && miliseconds > MainManager.Instance.BestMiliSeconds)
        {
            MainManager.Instance.BestMinutes = minutes;
            MainManager.Instance.BestSeconds = seconds;
            MainManager.Instance.BestMiliSeconds = miliseconds;
            MainManager.Instance.BestTimeName = MainManager.Instance.Name;
            MainManager.Instance.SaveHighScore(MainManager.Instance.Name, minutes, seconds, miliseconds);
        }

        MainManager.Instance.isGameOver = true;
        GameOverPanel.SetActive(true);

    }
}
