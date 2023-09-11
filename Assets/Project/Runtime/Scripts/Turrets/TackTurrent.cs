using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackTurrent : Turret
{
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
    protected override void Shoot()
    {
        for(int i = -1; i <2; i++)
        {
            for (int j = -1; j <2; j++)
            {
                Bullet bullet = BulletPool.Instance.bulletPool.Get();
                bullet.transform.position = this.transform.position;
                SetBulletStats(bullet);
                bullet.SetDirection(new Vector2(i, j));
            }
        }
    }
}
