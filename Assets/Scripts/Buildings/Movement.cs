using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f; // Adjust this to set the movement speed
    public Rigidbody rb;

    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        // Calculate movement direction based on the object's forward direction
        Vector3 movement = transform.forward * movementSpeed * Time.deltaTime;

        // Apply the movement to the object
        rb.MovePosition(rb.position + movement);
    }
}
