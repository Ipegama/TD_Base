using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class AttackTurret : Turret
{
    protected override void Shoot()
    {
        Bullet bullet = BulletPool.Instance.bulletPool.Get();
        bullet.transform.position = this.transform.position;
        SetBulletStats(bullet);
        bullet.SetTarget(target);
    }
    protected override bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
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
