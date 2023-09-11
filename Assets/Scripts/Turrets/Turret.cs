using UnityEditor;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [SerializeField] protected LayerMask enemyMask;
    [SerializeField] protected float targetingRange;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float attacksPerSecond;
    [SerializeField] protected bool isHoming;

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
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position,transform.forward,targetingRange);
    }
}
