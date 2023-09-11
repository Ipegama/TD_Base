using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPack 
{
    public GameObject EnemyPrefab;
    public int enemiesAmount;
    public float timeBetweenSpawning;
    public float timeToNextSpawningSO;
}
