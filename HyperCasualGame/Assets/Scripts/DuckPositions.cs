using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DuckPositions", menuName = "Duck position")]
public class DuckPositions : ScriptableObject
{
    public List<Vector3> possibleDuckPositions;
}