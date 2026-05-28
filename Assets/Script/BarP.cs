using UnityEngine;
using System.Collections;

public class BarP : MonoBehaviour
{
    [field: SerializeField]
    public int MaxValue { get; private set; } = 100;

    [field: SerializeField]
    public int Value { get; private set; } = 100;

    [SerializeField]
    private RectTransform _TopHealthP;

    [SerializeField]
    private RectTransform _BottomHealthP;

    [SerializeField]
    private float _animationSpeed = 10f;

    private float _fullWidth;
    private float TargetWidth => Value * _fullWidth / MaxValue;

    private Coroutine _adjustBarWidthCoroutine;

    private void Start()
    {
        _fullWidth = _TopHealthP.rect.width;

        // Start met volle HP
        Value = MaxValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("Enemy3"))
        {
            TakeDamage(10);
            Debug.Log("Speler geraakt");
        }
    }

    public void TakeDamage(int damage)
    {
        Change(-damage);
        if (Value <= 0)
        {
            PlayerDie();
        }
    }

    public void Heal(int amount)
    {
        Change(amount);
    }

    private void PlayerDie()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        TakeDamage(25);
    }

    if (Input.GetMouseButtonDown(1))
    {
        Heal(25);
    }
}
    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);

        if (_adjustBarWidthCoroutine != null)
        {
            StopCoroutine(_adjustBarWidthCoroutine);
        }

        _adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(amount));
    }

    private IEnumerator AdjustBarWidth(int amount)
    {
        RectTransform suddenChangeBar =
            amount < 0 ? _BottomHealthP : _TopHealthP;

        RectTransform slowChangeBar =
            amount < 0 ? _TopHealthP : _BottomHealthP;

        // direct de eerste bar aanpassen
        suddenChangeBar.SetWidth(TargetWidth);

        // tweede bar smooth laten volgen
        while (Mathf.Abs(slowChangeBar.rect.width - TargetWidth) > 1f)
        {
            slowChangeBar.SetWidth(
                Mathf.Lerp(
                    slowChangeBar.rect.width,
                    TargetWidth,
                    Time.deltaTime * _animationSpeed
                )
            );

            yield return null;
        }

        slowChangeBar.SetWidth(TargetWidth);
    }
}