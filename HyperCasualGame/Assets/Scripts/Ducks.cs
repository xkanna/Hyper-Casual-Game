using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ducks", menuName = "Duck prefabs")]
public class Ducks : ScriptableObject
{
    public List<GameObject> duckPrefabs;
}