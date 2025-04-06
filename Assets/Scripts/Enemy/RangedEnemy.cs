using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;

    [Header("Collider")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player layer")]
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;

    [Header("Movement")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private float speed;

    private bool isFacingRight = true;

    [Header("GeneralComponents")]
    [SerializeField] private Animator animator;
 

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("Attack");
                Attack();
            }
        }
        else
            Patrol();
    }

    private void Patrol()
    {
        if (isFacingRight && transform.position.x > rightEdge.position.x)
            Flip();
        else if (!isFacingRight && transform.position.x < leftEdge.position.x)
            Flip();

        transform.position = new Vector3(
            transform.position.x 
                + Time.deltaTime * speed * (isFacingRight ? 1f : -1f),
            transform.position.y,
            transform.position.z);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Attack()
    {
        cooldownTimer = 0;
        bullets[FindBullets()].transform.position = firePoint.position;
        bullets[FindBullets()]
            .GetComponent<EnemyProjectile>()
            .ActivateProjectile(damage);
    }

    private int FindBullets()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(
                boxCollider.bounds.center
                    + transform.right * range * transform.localScale.x * colliderDistance,
                new Vector3(
                    boxCollider.bounds.size.x * range,
                    boxCollider.bounds.size.y,
                    boxCollider.bounds.size.z),
                0,
                Vector2.left,
                0,
                playerLayer
            );

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center
                + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(
                boxCollider.bounds.size.x * range,
                boxCollider.bounds.size.y,
                boxCollider.bounds.size.z)
            );
    }
}
