using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{

    public static GameSystem Instance { get; private set; }
    public float dayCounter = 0;
    public float currentDay = 0;
    public float counter = 0;
    // public float timeSpeed = 0.01f;
    public GameObject earth;
    void Awake()
    {
        if (Instance != null) {
        Debug.LogError("There is more than one instance!");
        return;
        }

        Instance = this;
    }

    void Start()
    {
        earth = GameObject.Find("Earth");
    }
    void FixedUpdate()
    {
        // Time.fixedDeltaTime = timeSpeed;
        if (dayCounter % 365 == 0 && counter == 0) {
            Debug.Log("Day " + dayCounter);
            Debug.Log("Earth coordinates are: x: " + earth.transform.position.x + ", y: " + earth.transform.position.y);
        }
        counter++;
        if (counter == 100) {
            dayCounter++;
            // Debug.Log("Day " + dayCounter);
            counter = 0;
        }
        
        // dayCounter += Time.deltaTime;
        // if (Mathf.Floor(dayCounter) - 1 == currentDay) {
        //     currentDay = Mathf.Floor(dayCounter);
        //     // Debug.Log("Day #" + currentDay);
        // }
    }
}
