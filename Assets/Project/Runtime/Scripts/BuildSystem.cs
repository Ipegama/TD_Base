using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : Singleton<BuildSystem>
{
    [SerializeField] private Tower[] towers;

    private int selectedTower = 0;

    public Tower GetSelectedTower()=> towers[selectedTower];
    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
}
