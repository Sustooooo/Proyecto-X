using UnityEngine;

public class MaterialVectorUpdater : MonoBehaviour
{
    public Material targetMaterial; // Material que se modificará
    public string vector3PropertyName = "_CustomVector3"; // Nombre de la propiedad Vector3 en el Shader
    public string vector2PropertyName = "_CustomVector2"; // Nombre de la propiedad Vector2 en el Shader

    private Vector3 initialPosition;
    private Vector3 initialVector3;
    private Vector2 initialVector2;

    void Start()
    {
        if (targetMaterial == null)
        {
            Debug.LogError("No se ha asignado un material.");
            return;
        }

        if (!targetMaterial.HasProperty(vector3PropertyName))
        {
            Debug.LogError("El material no tiene la propiedad Vector3: " + vector3PropertyName);
            return;
        }

        if (!targetMaterial.HasProperty(vector2PropertyName))
        {
            Debug.LogError("El material no tiene la propiedad Vector2: " + vector2PropertyName);
            return;
        }

        // Guardar la posición inicial y los valores iniciales del material
        initialPosition = transform.position;
        initialVector3 = targetMaterial.GetVector(vector3PropertyName);
        initialVector2 = targetMaterial.GetVector(vector2PropertyName);
    }

    void Update()
    {
        if (targetMaterial == null) return;

        Vector3 positionOffset = transform.position - initialPosition;

        // Modificar el Vector3 del material
        Vector3 updatedVector3 = initialVector3 + new Vector3(positionOffset.x, positionOffset.z*-1f, 0)/1.5f;
        targetMaterial.SetVector(vector3PropertyName, updatedVector3);

        // Modificar el Vector2 del material (Z del Target afecta Y del Vector2)
        Vector2 updatedVector2 = initialVector2 + new Vector2(positionOffset.x, positionOffset.z)/1.5f;
        targetMaterial.SetVector(vector2PropertyName, updatedVector2);
    }
}