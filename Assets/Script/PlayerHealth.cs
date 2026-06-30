using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private BarP _barP;

    private void Start()
    {
        // pakt het Bar script van child object
        _barP = GetComponentInChildren<BarP>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            _barP.TakeDamage(10);

            if (_barP.Value <= 0)
            {
                PlayerDie();
            }
        }
    }

    private void PlayerDie()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}