using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator animator;
    private Bar _bar;
    public int health = 600;

    private void Start()
    {
        animator = GetComponent<Animator>();
        // pakt het Bar script van child object
        _bar = GetComponentInChildren<Bar>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            EnemyDie();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LightLazer")
        {
            health -= 20;
            Debug.Log(health);

            _bar.TakeDamage(20);

            if (_bar.Value <= 0)
            {
                EnemyDie();
            }
        }
    }

   public void EnemyDie()
    {
        animator.Play("Death Animation");
    Destroy(gameObject, 1.5f);
    }
}
