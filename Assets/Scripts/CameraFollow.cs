using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float lerpSpeed;

    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        var targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime); 
        
    }
}
