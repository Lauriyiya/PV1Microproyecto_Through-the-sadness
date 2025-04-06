using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth { get; private set; }
    [SerializeField] private float startingHealth;
    private bool IsDead;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        var tmpHealth = currentHealth - damage;

        currentHealth = Mathf.Clamp(tmpHealth, 0, startingHealth);

        if (currentHealth > 0)
        {
            animator.SetTrigger("Hurt");
            //iframes
        }
        else
        {
            if (!IsDead)
            {
                animator.SetTrigger("Death");
                GetComponent<PlayerMovement>().enabled = false;
                IsDead = true;
            }
        }
    }

    public float GetMaxHealth()
    {
        return startingHealth;
    }
}
