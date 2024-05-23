using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpeatBG : MonoBehaviour

{
    public float scrollSpeed = 4f;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }
    
    void Update()
    {

        transform.Translate(translation:Vector3.left * scrollSpeed * Time.deltaTime);
        if (transform.position.x < -3.247562)
        {
            transform.position = StartPosition;
        }

    }

}

