using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;
    public float lifeTime;
    public float growSpeed = 5f;
    private Vector3 targetSize;
    public bool shouldKnockBack;
    public bool destroyParent;
    void Start()
    {
        // Destroy(gameObject, lifeTime);
        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            targetSize = Vector3.zero;
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject);
                if (destroyParent)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockBack);
        }
    }
}
