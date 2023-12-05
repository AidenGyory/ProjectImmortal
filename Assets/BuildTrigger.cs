using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildTrigger : MonoBehaviour
{
    public int cost;
    public bool inRange;
    public bool isBuilding;
    public float buildTime;
    public bool buildingComplete; 

    public KeyCode payButton;
    public UnityEvent startBuilding;
    public UnityEvent buildingIsComplete;
    public UnityEvent playerInRange; 
    public UnityEvent playerOutOfRange; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            playerInRange?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false; 
            playerOutOfRange?.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(payButton) && inRange && !buildingComplete)
        {
            PayCoins(); 
        }

        if (isBuilding)
        {
            if (buildTime > 0f)
            {
                buildTime -= Time.deltaTime; 
            }
            else
            {
                isBuilding = false;
                buildingComplete = true; 
                buildingIsComplete?.Invoke();
                
            }
        }
    }

    void PayCoins()
    {
        var gameManager = FindObjectOfType<GameManager>();

        if (gameManager.coins >= cost)
        {
            isBuilding = true;
            gameManager.coins -= cost; 
            startBuilding?.Invoke();
            
        }
        else
        {
            Debug.Log("NOT ENOUGH COINS!!");
        }
    }
}
