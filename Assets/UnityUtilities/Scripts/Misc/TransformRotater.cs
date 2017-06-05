using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotater : MonoBehaviour {
    public Vector3 rotatingAxis;
    private Transform cacheTransform;
    private void Awake()
    {
        cacheTransform = transform;
    }

    private void Update()
    {
        cacheTransform.Rotate(rotatingAxis * Time.deltaTime);
    }
}
