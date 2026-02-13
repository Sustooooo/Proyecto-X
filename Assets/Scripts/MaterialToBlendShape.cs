using UnityEngine;

public class MaterialToBlendShape : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer; // Objeto con BlendShapes
    public int blendShapeIndex = 0; // Índice del BlendShape
    public Renderer targetRenderer; // Renderer que contiene el material
    public string materialProperty = "_BlendValue"; // Nombre del parámetro en el Shader

    private Material targetMaterial;

    void Start()
    {
        if (targetRenderer != null)
        {
            targetMaterial = targetRenderer.sharedMaterial; // Evita la duplicación de materiales
        }
    }

    void Update()
    {
        if (targetRenderer != null && targetRenderer.sharedMaterial != null)
        {
            if (targetRenderer.sharedMaterial.HasProperty(materialProperty))
            {
                float value = targetRenderer.sharedMaterial.GetFloat(materialProperty);
                //Debug.Log($"Valor obtenido de {materialProperty}: {value}");

                // Intentar modificar el BlendShape manualmente con este valor
                skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, value * 100f);
            }
            else
            {
                Debug.LogError($"El material NO tiene la propiedad '{materialProperty}'.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el Renderer o el Material.");
        }
    }
}
