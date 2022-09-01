using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject splashScreen;
    public DuckSpawner duckSpawner;
    public Button playButton;
    public Button unPauseButton;
    public PlayerData save;
    public TextMeshProUGUI numberOfTapsHighScoreText;
    public TextMeshProUGUI numberOfMergesHighScoreText;


    void Start()
    {
        save = new PlayerData();
        save.StartGame();
        numberOfTapsHighScoreText.text = save.GetPlayerTapHighScore().ToString();
        numberOfMergesHighScoreText.text = save.GetPlayerMergeHighScore().ToString();
    }

    void Update()
    {
        
    }

    public void OnPauseButtonClick()
    {
        pauseScreen.SetActive(true);
        duckSpawner.tapsEnabled = false;
    }

    public void OnPlayButtonClick()
    {
        splashScreen.SetActive(false);
        duckSpawner.tapsEnabled = true;
    }

    public void OnUnPauseButtonClick()
    {
        duckSpawner.tapsEnabled = true;
        pauseScreen.SetActive(false);
    }

    public void OnRestartButtonClick()
    {
        duckSpawner.tapsEnabled = true;
        duckSpawner.RestartGame();
        pauseScreen.SetActive(false);
    }
}
