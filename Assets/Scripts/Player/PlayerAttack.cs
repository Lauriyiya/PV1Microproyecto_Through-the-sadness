using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;
    private float cooldownTimer;

    [Header("GeneralComponents")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        if (Input.GetMouseButton(0) 
            && cooldownTimer > attackCooldown
            && playerMovement.CanAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("Attack"); 
        cooldownTimer = 0;
        
        bullets[FindBullets()].transform.position = firePoint.position;
        bullets[FindBullets()].GetComponent<Projectile>()
            .SetDirection(Mathf.Sign(transform.localScale.x));
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
}
