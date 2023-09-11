using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<SpawnPack> spawnPacks = new List<SpawnPack>();
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private void Start()
    {
        StartCoroutine(SpawnEnemiesCR());
    }

    public IEnumerator SpawnEnemiesCR()
    {
        for (int i = 0; i < spawnPacks.Count; i++)
        {
            SpawnPack spawnPack = spawnPacks[i];
            int amountToSpawn = spawnPack.enemiesAmount;

            while (amountToSpawn > 0)
            {
                Instantiate(spawnPack.EnemyPrefab, LevelManager.Instance.path[0].position, Quaternion.identity);
                yield return Helpers.GetWait(spawnPack.timeBetweenSpawning);
                amountToSpawn--;
            }
            yield return Helpers.GetWait(spawnPack.timeToNextSpawningSO);
        }

        yield return null;
    }

}
