using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed, lifeTime;
    [SerializeField] protected int bulletDamage;
    protected Transform target;
    protected Rigidbody2D rb;
    protected Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
    public void SetTarget(Transform transform)
    { 
        target = transform;
    }
    public void SetStats(float speed, int damage)
    {
        bulletSpeed = speed;
        bulletDamage = damage;
    }
    protected abstract void FixedUpdate();
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
