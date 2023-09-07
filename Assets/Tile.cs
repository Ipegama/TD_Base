using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;  
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        Tower towerToBuild = BuildManager.Instance.GetSelectedTower();

        if(towerToBuild.cost > LevelManager.Instance.currency)
        {
            return;
        }

        LevelManager.Instance.SpendCurrency(towerToBuild.cost);
        tower = Instantiate(towerToBuild.prefab,transform.position,Quaternion.identity);
    }

}
