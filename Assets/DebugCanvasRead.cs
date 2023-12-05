using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugCanvasRead : MonoBehaviour
{
    public TMP_Text currentTimeDisplay; 
    public TMP_Text currentDayDisplay; 
    public TMP_Text coinsDisplay; 
    public TMP_Text healthDisplay;

    public GameManager gameManager;
    public DayNightCycle dayNightCycle;

    private void Update()
    {
        currentDayDisplay.text = "Current Day: " + gameManager.currentDay;
        coinsDisplay.text = "Coins: " + gameManager.coins;
        healthDisplay.text = "Player health: " + gameManager.playerHealth + "/" + gameManager.playerMaxHealth;

        currentTimeDisplay.text = "time: " + ConvertToClockFormat(dayNightCycle.elapsedTime); 
    }

    string ConvertToClockFormat(float elapsedTime)
    {
        int hours = Mathf.FloorToInt(elapsedTime / 60);
        int minutes = Mathf.FloorToInt((elapsedTime / 600));

        return $"{hours}:{minutes}";
    }
}
