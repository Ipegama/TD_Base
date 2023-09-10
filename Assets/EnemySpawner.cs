using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<SpawningSO> spawningSO = new List<SpawningSO>();
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private void Start()
    {
        StartCoroutine(SpawnEnemiesCR());
    }

    public IEnumerator SpawnEnemiesCR()
    {
        for (int i = 0; i < spawningSO.Count; i++)
        {
            SpawningSO spawning = spawningSO[i];
            int amountToSpawn = spawning.enemiesAmount;

            while (amountToSpawn > 0)
            {
                Instantiate(spawning.EnemyPrefab, LevelManager.Instance.path[0].position, Quaternion.identity);
                yield return Helpers.GetWait(spawning.timeBetweenSpawning);
                amountToSpawn--;
            }
            yield return Helpers.GetWait(spawning.timeToNextSpawningSO);
        }

        yield return null;
    }

}
