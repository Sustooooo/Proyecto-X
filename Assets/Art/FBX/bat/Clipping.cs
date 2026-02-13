using UnityEngine;
using System.Collections;

public class Clipping : MonoBehaviour
{
    [Header("Material y Propiedad")]
    [SerializeField] private Material targetMaterial;
    [SerializeField] private string propertyName = "_Clipping";

    [Header("Tiempos")]
    [SerializeField] private float delay = 1.5f;
    [SerializeField] private float fadeInDuration = 1.5f;
    [SerializeField] private float stayDuration = 7f;
    [SerializeField] private float fadeOutDuration = 1.5f;

    private void Start()
    {
        // Asegurarse de que el valor inicial sea 0
        if (targetMaterial != null)
            targetMaterial.SetFloat(propertyName, 1f);

        // Iniciar la secuencia
        StartCoroutine(AnimateClipping());
    }

    private System.Collections.IEnumerator AnimateClipping()
    {
        // Esperar el delay inicial
        yield return new WaitForSeconds(delay);

        // Subir de 0 a 1
        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            float value = Mathf.Lerp(1f, 0f, t / fadeInDuration);
            targetMaterial.SetFloat(propertyName, value);
            yield return null;
        }

        // Mantener en 1 durante stayDuration
        targetMaterial.SetFloat(propertyName, 0f);
        yield return new WaitForSeconds(stayDuration);

        // Bajar de 1 a 0
        t = 0f;
        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            float value = Mathf.Lerp(0f, 1f, t / fadeOutDuration);
            targetMaterial.SetFloat(propertyName, value);
            yield return null;
        }

        // Asegurarse de dejarlo en 0 al final
        targetMaterial.SetFloat(propertyName, 1f);
    }
}

