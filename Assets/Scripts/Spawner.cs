using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;            // Prefab a instanciar
    public float spawnInterval = 2f;     // Tiempo entre instancias (en segundos)
    public float moveSpeed = 5f;         // Velocidad constante de movimiento en Z

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        GameObject instance = Instantiate(prefab, transform.position, transform.rotation);
        instance.AddComponent<MoveForward>().speed = moveSpeed;
    }
}
