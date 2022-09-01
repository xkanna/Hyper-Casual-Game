using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private int currentTapScore;
    private int currentMergeScore;

    public void StartGame()
    {
        currentTapScore = 0;
        currentMergeScore = 0;
    }

    public void SetPlayerTapHighScore(int playerTapScore)
    {
        PlayerPrefs.SetInt("playerTapHighScore", playerTapScore);
        PlayerPrefs.Save();
    }

    public int GetPlayerTapHighScore()
    {
        return PlayerPrefs.GetInt("playerTapHighScore");
    }

    public int GetPlayerTapScore()
    {
        return currentTapScore;
    }

    public void SetPlayerMergeHighScore(int playerMergeScore)
    {
        PlayerPrefs.SetInt("playerMergeHighScore", playerMergeScore);
        PlayerPrefs.Save();
    }

    public int GetPlayerMergeHighScore()
    {
        return PlayerPrefs.GetInt("playerMergeHighScore");
    }

    public int GetPlayerMergeScore()
    {
        return currentMergeScore;
    }

    public void UpdateTapValue()
    {
        int playerTapHighScore = PlayerPrefs.GetInt("playerTapHighScore");
        currentTapScore += 1;
        if (currentTapScore > playerTapHighScore)
        {
            PlayerPrefs.SetInt("playerTapHighScore", currentTapScore);
            PlayerPrefs.Save();
        }
    }

    public void UpdateMergeValue()
    {
        int playerMergeHighScore = PlayerPrefs.GetInt("playerMergeHighScore");
        currentMergeScore += 1;
        if (currentMergeScore > playerMergeHighScore)
        {
            PlayerPrefs.SetInt("playerMergeHighScore", currentMergeScore);
            PlayerPrefs.Save();
        }
    }

    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
