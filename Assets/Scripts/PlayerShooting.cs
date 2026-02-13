using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class PlayerShooting : MonoBehaviour
{
    public GameObject BombProjectile; // Prefab del proyectil bomba
    public GameObject RayProjectile; // Prefab del proyectil rayo
    public Transform shootPoint;        // Punto de salida del proyectil
    public float shootForce = 10f;       // Fuerza de disparo


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            StartCoroutine(ShootAfterDelay(2f)); // Espera 2 segundos antes de disparar
        }
        if (Input.GetMouseButtonDown(1)) // Click derecho
        {
            ShootBomb();
        }
    }

    IEnumerator ShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShootRay();

    }
    void ShootRay()
    {
        Instantiate(RayProjectile, shootPoint.position, shootPoint.rotation);
    }

    void ShootBomb()
    {
        if (BombProjectile != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(BombProjectile, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
            }
        }
    }

}
