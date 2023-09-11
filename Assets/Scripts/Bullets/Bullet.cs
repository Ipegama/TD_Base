using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected int bulletDamage;
    [SerializeField] bool _isHoming;
    private ObjectPool<Bullet> _pool;
    protected Transform target;
    protected Rigidbody2D rb;
    protected Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        StartCoroutine(BulletTimeLimit());
    }
    public void SetTarget(Transform transform)
    { 
        target = transform;
    }
    public void SetStats(float speed, int damage, ObjectPool<Bullet> pool, bool isHoming)
    {
        bulletSpeed = speed;
        bulletDamage = damage;
        _isHoming = isHoming;
        _pool = pool;
        gameObject.SetActive(true);
    }
    protected void FixedUpdate()
    {
        if (_isHoming)
        {
            if (!target) return;

            direction = (target.position - transform.position).normalized;
        }
        
        rb.velocity = direction * bulletSpeed;    
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        _pool.Release(this);
    }


    private IEnumerator BulletTimeLimit()
    {
        yield return Helpers.GetWait(1f);
        _pool.Release(this);
    }
}
