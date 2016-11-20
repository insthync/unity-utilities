using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}