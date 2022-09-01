using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuckSpawner : MonoBehaviour
{
    public Ducks ducks;
    public DuckPositions duckPositions;
    private int tapCounter;
    private int mergeCounter;
    private int type1DuckCounter;
    private int type2DuckCounter;
    private int type3DuckCounter;
    private int type4DuckCounter;
    private int type5DuckCounter;
    public List<GameObject> spawnedDucks;
    public TextMeshProUGUI numberOfTapsText;
    public TextMeshProUGUI numberOfMergesText;
    public TextMeshProUGUI numberOfTapsHighScoreText;
    public TextMeshProUGUI numberOfMergesHighScoreText;
    public GameObject explosion;
    public bool tapsEnabled;
    public PlayerData save;

    void Start()
    {
        save = new PlayerData();
        tapsEnabled = false;
        InitializeCounters();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tapsEnabled)
        {
            tapCounter++;
            if(type1DuckCounter < 10)
            {
                GameObject newDuckType1 = Instantiate(ducks.duckPrefabs[0], duckPositions.possibleDuckPositions[spawnedDucks.Count], Quaternion.Euler(new Vector3(-90, 0, -90)));
                type1DuckCounter++;
                spawnedDucks.Add(newDuckType1);
            }
            else if (type1DuckCounter == 10)
            {
                type1DuckCounter = 0;
                Destroy10Ducks();
                type2DuckCounter++;
                InstantiateNewDuck(1);
                mergeCounter++;
                save.UpdateMergeValue();
            }

            if (type2DuckCounter == 10)
            {
                type2DuckCounter = 0;
                Destroy10Ducks();
                type3DuckCounter++;
                InstantiateNewDuck(2);
                mergeCounter++;
                save.UpdateMergeValue();
            }

            if (type3DuckCounter == 10)
            {
                type3DuckCounter = 0;
                Destroy10Ducks();
                type4DuckCounter++;
                InstantiateNewDuck(3);
                mergeCounter++;
                save.UpdateMergeValue();
            }

            if (type4DuckCounter == 10)
            {
                type4DuckCounter = 0;
                Destroy10Ducks();
                type5DuckCounter++;
                InstantiateNewDuck(4);
                mergeCounter++;
                save.UpdateMergeValue();
            }
            save.UpdateTapValue();
            UpdateUI();
        }
        
    }

    private void Destroy10Ducks()
    {
        for (int i = 0; i < 10; i++)
        {
            Destroy(spawnedDucks[spawnedDucks.Count - 1]);
            Instantiate(explosion, spawnedDucks[spawnedDucks.Count - 1].transform.position, spawnedDucks[spawnedDucks.Count - 1].transform.rotation);
            spawnedDucks.Remove(spawnedDucks[spawnedDucks.Count - 1]);
        }
    }

    private void InstantiateNewDuck(int duckType)
    {
        GameObject newDuckType = Instantiate(ducks.duckPrefabs[duckType], duckPositions.possibleDuckPositions[spawnedDucks.Count], Quaternion.Euler(new Vector3(-90, 0, -90)));
        spawnedDucks.Add(newDuckType);
    }

    private void UpdateUI()
    {
        numberOfTapsText.text = tapCounter.ToString();
        numberOfMergesText.text = mergeCounter.ToString();
        numberOfTapsHighScoreText.text = save.GetPlayerTapHighScore().ToString();
        numberOfMergesHighScoreText.text = save.GetPlayerMergeHighScore().ToString();
    }

    public void RestartGame()
    {
        int deletionsNumber = spawnedDucks.Count;
        for (int i = 0; i < deletionsNumber; i++)
        {
            Destroy(spawnedDucks[spawnedDucks.Count - 1]);
            spawnedDucks.Remove(spawnedDucks[spawnedDucks.Count - 1]);
        }

        InitializeCounters();
        UpdateUI();
    }

    private void InitializeCounters()
    {
        tapCounter = 0;
        mergeCounter = 0;
        type1DuckCounter = 0;
        type2DuckCounter = 0;
        type3DuckCounter = 0;
        type4DuckCounter = 0;
        type5DuckCounter = 0;
    }
}
