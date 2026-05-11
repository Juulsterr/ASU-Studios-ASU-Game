using UnityEngine;

public class ShootLazers : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float lazerSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootLazer()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject LightLazer = Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }

    
}
