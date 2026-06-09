using UnityEngine;

public class BossSlashAim : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;

    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            speed * Time.deltaTime
        );
    }
}
