using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBullet : Bullet
{
    protected override void FixedUpdate()
    {
        rb.velocity = direction.normalized * bulletSpeed;
    }
}
