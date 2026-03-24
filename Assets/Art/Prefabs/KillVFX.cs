using UnityEngine;
using UnityEngine.VFX;

public class KillVFX : MonoBehaviour
{
    public VisualEffect vfx;
    public float speed = 7f;

    void Start()
    {
        vfx.SetBool("IsActive", true);
    }

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        vfx.SetBool("IsActive", false);
        vfx.SendEvent("OnHit");
        GetComponent<SphereCollider>().enabled = false;
    }
}
