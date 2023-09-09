using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    public GameObject towerObj;
    public Turret turret;
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
        if (UIManager.Instance.IsHoveringOverUI())
        {
            return;
        }
        Tower towerToBuild = BuildManager.Instance.GetSelectedTower();

        if(towerToBuild.cost > LevelManager.Instance.currency)
        {
            return;
        }

        LevelManager.Instance.SpendCurrency(towerToBuild.cost);
        towerObj = Instantiate(towerToBuild.prefab,transform.position,Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();
    }

}
