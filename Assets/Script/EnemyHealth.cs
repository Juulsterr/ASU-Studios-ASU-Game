using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemySpawner spawner;
    private Bar _bar;
    public int health = 100;

    private void Start()
    {
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
            health -= 34;
            Debug.Log(health);

            _bar.TakeDamage(25);

            if (_bar.Value <= 0)
            {
                EnemyDie();
            }
        }
    }

   public void EnemyDie()
{
    if (spawner != null)
    {
        // spawner.EnemyKilled(); //moet nog worden toegevoegd in EnemySpawner.cs
    }

    Destroy(gameObject);
}
}