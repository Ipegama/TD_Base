using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : Bullet
{
    protected override void FixedUpdate()
    {
        if (!target) return;

        Vector2 dir = (target.position - transform.position).normalized;
        rb.velocity = dir * bulletSpeed;
    }
}
