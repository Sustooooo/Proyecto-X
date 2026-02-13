using UnityEngine;

public class Orbital_Camera : MonoBehaviour
{
    public Transform target; // Objeto alrededor del cual orbitará la cámara.
    public float orbitSpeed = 10f; // Velocidad de la órbita.
    public float distance = 5f; // Distancia desde el objeto.
    public Vector3 axis = Vector3.up; // Eje de rotación (por defecto, el eje Y).

    private void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("OrbitCamera: No hay un objeto objetivo asignado.");
            return;
        }

        // Rotar la posición de la cámara alrededor del objetivo
        transform.RotateAround(target.position, axis, orbitSpeed * Time.deltaTime);

        // Mantener la distancia al objetivo
        Vector3 direction = (transform.position - target.position).normalized;
        transform.position = target.position + direction * distance;

        // Apuntar siempre al objetivo
        transform.LookAt(target);
    }
}