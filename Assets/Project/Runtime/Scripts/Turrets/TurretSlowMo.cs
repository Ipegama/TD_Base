using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TurretSlowMo : Turret
{
    [SerializeField] private float freezeTime = 1f;
    protected List<EnemyMovement> targets = new List<EnemyMovement>();
    
    private IEnumerator ResetEnemySpeed(EnemyMovement enemyMovement)
    {
        yield return new WaitForSeconds(freezeTime);
        enemyMovement.ResetSpeed();
    }

    protected override void Shoot()
    {
        foreach(EnemyMovement enemy in targets)
        {
            enemy.UpdateSpeed(0.5f);
            StartCoroutine(ResetEnemySpeed(enemy));
        }      
    }

    protected override bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    protected override void FindTarget()
    {
        targets.Clear();
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
        foreach (RaycastHit2D hit in hits)
        {
            targets.Add(hit.transform.GetComponent<EnemyMovement>());
        }
    }
}
