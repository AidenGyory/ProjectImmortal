using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryPickup : MonoBehaviour
{

    public UnityEvent OnPickUp; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().coins += 1; 
            OnPickUp?.Invoke();
            Destroy(gameObject);

        }
    }
}
