using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour
{
    [field: SerializeField]
    public int MaxValue { get; private set; } = 100;

    [field: SerializeField]
    public int Value { get; private set; }

    [SerializeField]
    private RectTransform _TopHealthE1;

    [SerializeField]
    private RectTransform _BottomHealthE1;

    [SerializeField]
    private float _animationSpeed = 10f;

    private float _fullWidth;
    private float TargetWidth => Value * _fullWidth / MaxValue;

    private Coroutine _adjustBarWidthCoroutine;

    private void Start()
    {
        _fullWidth = _TopHealthE1.rect.width;

        // Start met volle HP
        Value = MaxValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LightLazer"))
        {
            TakeDamage(25);
            Debug.Log("Enemy geraakt");
        }
    }

    public void TakeDamage(int damage)
    {
        Change(-damage);

        if (Value <= 0)
        {
            EnemyDie();
        }
    }

    public void Heal(int amount)
    {
        Change(amount);
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
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
            amount < 0 ? _BottomHealthE1 : _TopHealthE1;

        RectTransform slowChangeBar =
            amount < 0 ? _TopHealthE1 : _BottomHealthE1;

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