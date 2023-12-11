using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class EnemyInfo : MonoBehaviour
{
    public int health;
    public Action TriggerDeath;
    public GameObject batteryPrefab; 


    void Start()
    {
        TriggerDeath += OnDeath; 
    }

    // Update is called once per frame
    public void takeDamage(int amount)
    {
        health -= amount; 
        if (health < 1)
        {
            TriggerDeath?.Invoke();
        }
    }

    private void OnDeath()
    {
        var coin = Instantiate(batteryPrefab, transform.position, quaternion.identity); 
        Destroy(transform.parent.gameObject);

    }
}
