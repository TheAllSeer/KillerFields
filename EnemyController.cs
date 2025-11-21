using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Transform target;
    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;

    public float health = 5f;

    public float knockBackTime = 0.5f;
    private float knockBackCounter;

    void Start()
    {
        target = PlayerHealthController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;
            if (moveSpeed > 0)
            {
                moveSpeed = -moveSpeed * 2f;
            }
            if (knockBackCounter <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
                knockBackCounter = 0;
            }

        }
        rb.linearVelocity = (target.position - transform.position).normalized * moveSpeed;
        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hitCounter <= 0f)
        {
            PlayerHealthController.instance.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        DamageNumberController.instance.SpawnDamage(damage, transform.position);
    }

    public void TakeDamage(float damage, bool shouldKnockBack)
    {
        TakeDamage(damage);
        if (shouldKnockBack)
        {
            knockBackCounter = knockBackTime;
        }
    }
}
