using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpeatBG : MonoBehaviour

{
    public float scrollSpeed;
    Vector3 StartPosition;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        StartPosition = transform.position;
    }
    
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);

        /*transform.Translate(translation:Vector3.left * scrollSpeed * Time.deltaTime);
        if (transform.position.x < -3.247562)
        {
            transform.position = StartPosition;
        }*/
    }

}

