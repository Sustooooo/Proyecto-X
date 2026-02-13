using UnityEngine;
using UnityEngine.VFX; // Importante para manejar VFX Graph
using System.Collections.Generic;

public class PlayAnimationAndVFXGraph : MonoBehaviour
{
    public Animator animator;      // Referencia al Animator
    public List<VisualEffect> vfxGraphs = new List<VisualEffect>();  // Lista de referencias a VFX Graphs
    public string animationName;   // Nombre de la animación a reproducir
    public GameObject Enemy;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(Enemy);
            // Reproducir animación
            if (animator != null)
            {
                animator.Play(animationName);
            }

            // Activar todos los VFX Graphs en la lista
            foreach (var vfx in vfxGraphs)
            {
                if (vfx != null)
                {
                    vfx.Play();
                }
            }
        }
    }
}
