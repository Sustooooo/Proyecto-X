using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class ExplosionProyectile : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletTrail;
    public GameObject ExplosionVFX;
    public float LifetimeVFX = 6.0f;
    

    void Start()
    {
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Asignar el tag "Ground" al suelo para que rebote en los demás objetos y solo en el suelo explote.
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Destruye el Collider del proyectil.
            SphereCollider sphere = GetComponent<SphereCollider>();
            if (sphere != null)
            {
                Destroy(sphere);
            }

            //Destruye el trail de la bala. Se espera X segundo para que termine su trayecto y luego se destruya.
            if (BulletTrail != null)
            {
                Destroy(BulletTrail,0.5f);
            }

            // Destruye la bala.
            if (Bullet != null)
            {
                Destroy(Bullet);
            }

            // Detener el movimiento del proyectil.
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Destroy(rb);
            }


            // Obtiene el punto de contacto más cercano.
            Vector3 contactPoint = collision.contacts[0].point;

            if (ExplosionVFX != null)
            {
                //Instancia un Prefab del VFX en el punto de contacto.
                GameObject vfxInstance = Instantiate(ExplosionVFX, contactPoint, Quaternion.identity);

                //Asegura que se reproduzca el VFX
                VisualEffect vfx = vfxInstance.GetComponent<VisualEffect>();
                if (vfx != null)
                {
                    vfx.Play();
                }
               
                StartCoroutine(DestroyVFX(vfxInstance, LifetimeVFX));

               
            }
        }
    }

    //Destuye el VFX despues de X segundos y luego el Proyectil con el script.
    IEnumerator DestroyVFX(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
        yield return new WaitForSeconds(delay / 100f);
        Destroy(gameObject);
    }

}