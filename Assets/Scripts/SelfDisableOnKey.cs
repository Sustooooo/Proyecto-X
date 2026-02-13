using UnityEngine;
using System.Collections;

public class SelfDisableOnKey : MonoBehaviour
{
    public float disableDuration = 3f; // Tiempo en segundos que estará desactivado
    public GameObject Health;
    public GameObject Cooldown;

    private void Start()
    {
        Cooldown.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Cooldown != null)
            {
                Cooldown.SetActive(true);
            }

            StartCoroutine(DisableCoroutine());
        }
    }

    private IEnumerator DisableCoroutine()
    {
        Health.SetActive(false);
        yield return new WaitForSeconds(disableDuration);
        Health.SetActive(true);
    }
}      
