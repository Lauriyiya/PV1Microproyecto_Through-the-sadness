using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    [SerializeField] private BoxCollider2D boxCollider;
    private float lifeTime;
    private bool hit;

    public void ActivateProjectile()
    {
        hit = false;
        lifeTime = 0;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
    }
    public void ActivateProjectile(float damage)
    {
        hit = false;
        lifeTime = 0;

        this.damage = damage;

        boxCollider.enabled = true;
        gameObject.SetActive(true);
    }

    public void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);
        boxCollider.enabled = false;

        gameObject.SetActive(false);
    }
}
