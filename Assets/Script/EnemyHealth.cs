using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Bar _bar;

    private void Start()
    {
        // pakt het Bar script van child object
        _bar = GetComponentInChildren<Bar>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _bar.TakeDamage(25);

            if (_bar.Value <= 0)
            {
                EnemyDie();
            }
        }
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
    }
}