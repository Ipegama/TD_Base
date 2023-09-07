using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Singleton<BuildManager>
{
    [SerializeField] private GameObject[] towersPrefabs;

    private int selectedTower = 0;

    public GameObject GetSelectedTower()
    {
        return towersPrefabs[selectedTower];
    }
}
