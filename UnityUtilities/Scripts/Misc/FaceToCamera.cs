using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    public Camera targetCamera;
    void FixedUpdate()
    {
        Camera camera = targetCamera;
        if (camera == null)
            camera = Camera.main;
        transform.forward = camera.transform.forward;
    }
}
