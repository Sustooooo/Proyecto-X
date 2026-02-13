using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class ImpactFrameScript : MonoBehaviour
{
    public Material targetMaterial;
    public KeyCode triggerKey = KeyCode.Space;
    public VisualEffect vfxGraph;
    public float Delay = 0.05f;

    [Header("Directional Lights")]
    public GameObject normalLight;
    public GameObject invertedLight;
    public GameObject SpotLight;

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            StartCoroutine(TriggerSequence());
        }
    }

    IEnumerator TriggerSequence()
    {
        if (normalLight != null) normalLight.SetActive(false);
        if (invertedLight != null) invertedLight.SetActive(true);
        if (invertedLight != null) SpotLight.SetActive(true);

        // Disparar VFX Graph
        if (vfxGraph != null)
            vfxGraph.Play();

        // Activar Alpha inmediatamente
        targetMaterial.SetFloat("_Alpha", 1f);

        // Esperar
        yield return new WaitForSeconds(Delay);

        // Activar Inverse
        targetMaterial.SetFloat("_Inverse", 1f);

        // Esperar
        yield return new WaitForSeconds(Delay);

        // Desactivar Alpha
        if (invertedLight != null) invertedLight.SetActive(false);
        if (normalLight != null) SpotLight.SetActive(false);
        if (normalLight != null) normalLight.SetActive(true);

        targetMaterial.SetFloat("_Alpha", 0f);
        
        yield return new WaitForSeconds(Delay);

        //Inverse OFF
        targetMaterial.SetFloat("_Inverse", 0f);

    }
}
