using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool shielded;
    private BarP _barP;

    private void Start()
    {
        shielded = false;
        // pakt het Bar script van child object
        _barP = GetComponentInChildren<BarP>();
    }

    private void Update()
    {
        CheckShield();
    }
    void CheckShield()
    {
        if (Input.GetMouseButton(1) &&! shielded)
        {
            shielded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("DarkEnergy"))
        {
            if (!shielded)
            {
            _barP.TakeDamage(10);

            if (_barP.Value <= 0)
            {
                PlayerDie();
            }
                
            }
        }
        if (collision.gameObject.CompareTag("SwordSlash"))
        {
            if (!shielded)
            {
            _barP.TakeDamage(25);
            if (_barP.Value <= 0)
            {
                PlayerDie();
            }
                
            }
        }
    }


    private void PlayerDie()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}