using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int bulletDamage = 1;

    private Transform target;

    public void SetTarget(Transform transform)
    { 
        target = transform;
    }

    private void FixedUpdate()
    {
        if(!target) return;

        Vector2 dir = (target.position - transform.position).normalized;
        rb.velocity = dir * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
