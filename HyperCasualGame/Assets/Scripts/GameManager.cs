using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using GameAnalyticsSDK;
using Facebook.Unity;

public class GameManager : MonoBehaviour
{
    public PlayerData save;
    public DuckSpawner duckSpawner;

    public GameObject pauseScreen;
    public GameObject splashScreen;
    
    public Button playButton;
    public Button unPauseButton;
    public TextMeshProUGUI numberOfTapsHighScoreText;
    public TextMeshProUGUI numberOfMergesHighScoreText;

    void Start()
    {
        FB.Init();
        GameAnalytics.Initialize();
        GameAnalytics.NewDesignEvent("Event Started");
        save = new PlayerData();
        save.StartGame();
        UpdateUI();
    }

    private void UpdateUI()
    {
        numberOfTapsHighScoreText.text = save.GetPlayerTapHighScore().ToString();
        numberOfMergesHighScoreText.text = save.GetPlayerMergeHighScore().ToString();
    }

    public void OnPauseButtonClick()
    {
        GameAnalytics.NewDesignEvent("Game Paused");
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
