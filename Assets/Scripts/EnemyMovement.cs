using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 2f;
    private Transform target;
    private int pathIndex = 1;


    private float baseSpeed;

    private void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.Instance.path[pathIndex];
    }

    private void Update()
    {
        if(Vector2.Distance(target.position,transform.position)<= 0.02f)
        {
            pathIndex++;
           

            if (pathIndex == LevelManager.Instance.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }

            target = LevelManager.Instance.path[pathIndex];
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
