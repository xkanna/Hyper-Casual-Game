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

    void Start()
    {
        tapCounter = 0;
        type1DuckCounter = 0;
        type2DuckCounter = 0;
        type3DuckCounter = 0;
        type4DuckCounter = 0;
        type5DuckCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                
                for(int i = 0; i < 10; i++)
                {
                    Destroy(spawnedDucks[spawnedDucks.Count - 1]);
                    spawnedDucks.Remove(spawnedDucks[spawnedDucks.Count - 1]);
                }

                GameObject newDuckType2 = Instantiate(ducks.duckPrefabs[1], duckPositions.possibleDuckPositions[spawnedDucks.Count], Quaternion.Euler(new Vector3(-90, 0, -90)));
                type2DuckCounter++;
                spawnedDucks.Add(newDuckType2);
                mergeCounter++;
            }

            if (type2DuckCounter == 10)
            {
                type2DuckCounter = 0;

                for (int i = 0; i < 10; i++)
                {
                    Destroy(spawnedDucks[spawnedDucks.Count - 1]);
                    spawnedDucks.Remove(spawnedDucks[spawnedDucks.Count - 1]);
                }

                type3DuckCounter++;
                GameObject newDuckType3 = Instantiate(ducks.duckPrefabs[2], duckPositions.possibleDuckPositions[spawnedDucks.Count], Quaternion.Euler(new Vector3(-90, 0, -90)));
                spawnedDucks.Add(newDuckType3);
                mergeCounter++;
            }

            if (type3DuckCounter == 10)
            {
                type3DuckCounter = 0;

                for (int i = 0; i < 10; i++)
                {
                    Destroy(spawnedDucks[spawnedDucks.Count - 1]);
                    spawnedDucks.Remove(spawnedDucks[spawnedDucks.Count - 1]);
                }

                type4DuckCounter++;
                GameObject newDuckType4 = Instantiate(ducks.duckPrefabs[3], duckPositions.possibleDuckPositions[spawnedDucks.Count], Quaternion.Euler(new Vector3(-90, 0, -90)));
                spawnedDucks.Add(newDuckType4);
                mergeCounter++;
            }

            if (type4DuckCounter == 10)
            {
                type4DuckCounter = 0;

                for (int i = 0; i < 10; i++)
                {
                    Destroy(spawnedDucks[spawnedDucks.Count - 1]);
                    spawnedDucks.Remove(spawnedDucks[spawnedDucks.Count - 1]);
                }

                type5DuckCounter++;
                GameObject newDuckType5 = Instantiate(ducks.duckPrefabs[4], duckPositions.possibleDuckPositions[spawnedDucks.Count], Quaternion.Euler(new Vector3(-90, 0, -90)));
                spawnedDucks.Add(newDuckType5);
                mergeCounter++;
            }
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        numberOfTapsText.text = tapCounter.ToString();
        numberOfMergesText.text = mergeCounter.ToString();
    }
}
