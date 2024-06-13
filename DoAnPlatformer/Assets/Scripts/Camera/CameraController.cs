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
        target = FindObjectOfType<PlayerController>().transform;
        cam = GetComponent<Camera>();

        halfHeight = cam.orthographicSize;
        halfWidth = cam.orthographicSize * cam.aspect;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 1.5f, transform.position.z); 
    }

}
