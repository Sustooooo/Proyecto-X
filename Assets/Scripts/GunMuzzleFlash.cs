using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class GunMuzzleFlash : MonoBehaviour
{
    public GameObject SpawnRayPrefab; // Tu prefab del VFX
    public GameObject SpawnBombPrefab;
    public Transform target;     // El GameObject objetivo
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botón izquierdo del mouse
        {
            SpawnRayVFX();
        }
        if (Input.GetMouseButtonDown(1)) // Botón izquierdo del mouse
        {
            SpawnBombVFX();
        }
    }

    void SpawnRayVFX()
    {
        // Instanciar el VFX en la misma posición y rotación que el target, y hacerlo hijo
        GameObject vfxInstance = Instantiate(SpawnRayPrefab, target.position, target.rotation, target);

        // Opcional: copiar también la escala si es necesario
        vfxInstance.transform.localScale = target.localScale;

        // Destruir el VFX después de 2 segundos
        Destroy(vfxInstance, 2f);
    }
    void SpawnBombVFX()
    {
        // Instanciar el VFX en la misma posición y rotación que el target, y hacerlo hijo
        GameObject vfxInstance = Instantiate(SpawnBombPrefab, target.position, target.rotation, target);

        // Opcional: copiar también la escala si es necesario
        vfxInstance.transform.localScale = target.localScale;

        // Destruir el VFX después de 2 segundos
        Destroy(vfxInstance, 2f);
    }
}
