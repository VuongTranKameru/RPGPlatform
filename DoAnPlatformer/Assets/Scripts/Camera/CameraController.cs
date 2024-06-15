using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Camera cam;
    private float halfWidth,halfHeight;

    void Awake()
    {
        cam = GetComponent<Camera>();

        halfHeight = cam.orthographicSize;
        halfWidth = cam.orthographicSize * cam.aspect;
    }

    private void FixedUpdate()
    {
        target = FindObjectOfType<PlayerManager>().transform;
    }

    private void LateUpdate()
    {
        if (target != null)
            transform.position = new Vector3(target.position.x, target.position.y + 1.5f, transform.position.z); 
    }

}
