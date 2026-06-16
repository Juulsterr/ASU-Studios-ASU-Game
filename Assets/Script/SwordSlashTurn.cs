using UnityEngine;

public class SwordSlashTurn : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = targetRotation;
    }

    void Update()
    {
        
    }
}
