using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class EnterVFX : MonoBehaviour
{

    public VisualEffect TargetVFX;
    //public GameObject EnemyMesh;
    //public GameObject VFX;
                                
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TargetVFX.Reinit();
            TargetVFX.SendEvent("Evento");
        }



    }
}
