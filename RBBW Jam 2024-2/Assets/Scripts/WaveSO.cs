using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "ScriptableObjects/WaveScriptableObject", order = 2)]
public class WaveSO : ScriptableObject
{
    public int spawnDelay;
    public List<Shape> enemyTypes;
    public List<int> enemynrs;
   
}
