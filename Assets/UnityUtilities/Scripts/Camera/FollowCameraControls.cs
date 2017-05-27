using UnityEngine;

public class FollowCameraControls : MonoBehaviour {
    public Camera targetCamera;
    public bool updateRotation = true;
    public bool updateZoom = true;
    public float minXRotation;
    public float maxXRotation;
    public float rotationSpeed;
    public float minZoomDistance;
    public float maxZoomDistance;
    public float zoomSpeed;
    public Transform target;
    private FollowCamera targetFollowCamera;
    private Transform dirtyTarget;

    // Use this for initialization
    void Awake()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        targetFollowCamera = targetCamera.gameObject.GetComponent<FollowCamera>();
        if (targetFollowCamera == null)
            targetFollowCamera = targetCamera.gameObject.AddComponent<FollowCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != dirtyTarget)
        {
            targetFollowCamera.target = target;
            dirtyTarget = target;
        }


        if (updateRotation)
        {
            var mX = InputManager.GetAxis("Mouse X", false);
            var mY = InputManager.GetAxis("Mouse Y", false);
            targetFollowCamera.xRotation += mY * rotationSpeed;
            targetFollowCamera.xRotation = Mathf.Clamp(targetFollowCamera.xRotation, minXRotation, maxXRotation);
            targetFollowCamera.yRotation += mX * rotationSpeed;
        }

        if (updateZoom)
        {
            var mZ = InputManager.GetAxis("Mouse ScrollWheel", false);
            targetFollowCamera.zoomDistance += mZ * zoomSpeed;
            targetFollowCamera.zoomDistance = Mathf.Clamp(targetFollowCamera.zoomDistance, minZoomDistance, maxZoomDistance);
        }
    }
}
