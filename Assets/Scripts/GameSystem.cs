using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{

    public static GameSystem Instance { get; private set; }
    public Movement movement;
    public float dayCounter = 0;
    public float currentDay = 0;
    public float timeSpeed = 1f; // 10 days per second
    private float timeSpeedChange = 0;
    public bool isPaused = false;
    public TMP_Text dateText;
    private GameObject earth;
    private float counter = 0;
    void Awake()
    {
        Time.fixedDeltaTime = Globals.timeStep;
        if (Instance != null) {
        Debug.LogError("There is more than one instance!");
        return;
        }

        Instance = this;
    }

    void Start()
    {
        earth = GameObject.Find("Earth");
        Time.fixedDeltaTime = Globals.timeStep;
    }
    void FixedUpdate()
    {
        if (!isPaused) {
            if (dayCounter % 365 == 0 && counter == 0) {
            }
            counter++;
            if (counter > 100 / timeSpeed) {
                dayCounter++;
                counter = 0;
                updateDate();
            }
        }
    }

    public void Pause() {
        isPaused = !isPaused;
    }

    public void TimeSpeedUp() {
        if (timeSpeed < 10) {
            timeSpeed += 0.5f;
            timeSpeedChange = timeSpeed / (timeSpeed - 0.5f);
            movement.AdjustToTimeSpeed(timeSpeedChange);
        }
    }

    public void TimeSpeedDown() {
        if (timeSpeed > 0.5) {
            timeSpeed -= 0.5f;
            timeSpeedChange = timeSpeed / (timeSpeed + 0.5f);
            movement.AdjustToTimeSpeed(timeSpeedChange);
        }
    }

    public void updateDate() {
        dateText.text = "Day " + dayCounter;
    }
}
