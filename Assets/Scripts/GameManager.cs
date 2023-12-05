using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int currentDay;
    public int coins;
    public int playerHealth;
    public int playerMaxHealth;

    public UnityEvent newDayTrigger; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void NewDay()
    {
        currentDay++; 
        newDayTrigger?.Invoke();
        
    }
}
