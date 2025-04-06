using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public float currentHealth { get; private set; }
    [SerializeField] private float startingHealth;
    private bool IsDead;

    [Header("IFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("GeneralComponents")]
    [SerializeField] private Animator animator;
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private IEnumerator Invulnerabilty()
    {
        // Ignore traps and enemies
        Physics2D.IgnoreLayerCollision(7, 9, true);
        Physics2D.IgnoreLayerCollision(7, 10, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

        // Reset collisions
        Physics2D.IgnoreLayerCollision(7, 9, false);
        Physics2D.IgnoreLayerCollision(7, 10, false);
    }

    public void TakeDamage(float damage)
    {
        var tmpHealth = currentHealth - damage;
        currentHealth = Mathf.Clamp(tmpHealth, 0, startingHealth);

        if (currentHealth > 0)
        {
            //animator.SetTrigger("Hurt");
            StartCoroutine(Invulnerabilty());
        }
        else
        {
            if (!IsDead)
            {
                animator.SetTrigger("Death");

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                IsDead = true;

            }
        }
    }

    public float GetMaxHealth()
    {
        return startingHealth;
    }
}
