using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Spawning So", menuName = "Spawning SO")]
public class SpawningSO : ScriptableObject
{
    public GameObject EnemyPrefab;
    public int enemiesAmount;
    public float timeBetweenSpawning;
    public float timeToNextSpawningSO;
}
