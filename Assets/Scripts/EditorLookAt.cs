using UnityEngine;

[ExecuteAlways]
public class EditorLookAtCamera : MonoBehaviour
{
    void Update()
    {
        if (Application.isPlaying) return;

        Camera targetCam = Camera.main;

#if UNITY_EDITOR
        if (UnityEditor.SceneView.lastActiveSceneView != null && UnityEditor.SceneView.lastActiveSceneView.camera != null)
        {
            targetCam = UnityEditor.SceneView.lastActiveSceneView.camera;
        }
#endif

        if (targetCam != null)
        {
            transform.LookAt(targetCam.transform, targetCam.transform.up);
        }
    }
}
