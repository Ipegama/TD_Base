using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class SniperTurret : Turret
{
    [SerializeField] protected float targetingRangeMin;

    protected override void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
    protected override bool CheckTargetIsInRange()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        return distance <= targetingRange && distance >= targetingRangeMin;
    }
    protected override void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}
