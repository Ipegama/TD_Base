using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : Singleton<BulletPool>
{
    [SerializeField] GameObject bulletPrefab;
    public ObjectPool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet,
            null,
            OnPutBackInBool,
            defaultCapacity: 20
            );
    }
    public Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bulletPrefab,this.transform).GetComponent<Bullet>();
        return newBullet;
    }
    private void OnPutBackInBool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
