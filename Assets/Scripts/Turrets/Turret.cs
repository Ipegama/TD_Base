using UnityEditor;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [Header("Turret Stats")]
    [SerializeField] protected LayerMask enemyMask;
    [SerializeField] protected float targetingRange;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float attacksPerSecond;

    [Header("Bullet Stats")]
    [SerializeField] protected bool isHoming;
    [SerializeField] protected int bulletDamage;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float bulletLifeTime;

    protected Transform target;
    protected float timeUntilFire;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if(timeUntilFire >= 1f / attacksPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    protected abstract void Shoot();
    protected abstract bool CheckTargetIsInRange();
    protected abstract void FindTarget();
    protected void SetBulletStats(Bullet bullet)
    {
        bullet.SetStats(bulletSpeed, bulletDamage, BulletPool.Instance.bulletPool, isHoming, bulletLifeTime);
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position,transform.forward,targetingRange);
    }

}
