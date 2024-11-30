using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Planet[] planets;
    List<MovingObject> movingObjects;
    public GameSystem gameSystem;
    void Awake()
    {
        movingObjects = new List<MovingObject>(FindObjectsByType<MovingObject>(FindObjectsSortMode.None));
        planets = FindObjectsByType<Planet>(FindObjectsSortMode.None);
        for (int i = 0; i < movingObjects.Count; i++) {
            movingObjects[i].SetStartVelocity(gameSystem.timeSpeed);
        }
        // Time.fixedDeltaTime = Globals.timeStep;
    }

    void FixedUpdate()
    {
        if (!gameSystem.isPaused) {
            for (int i = 0; i < movingObjects.Count; i++) {
                if (movingObjects[i] != null) {
                    movingObjects[i].UpdateVelocity(planets, Globals.timeStep, gameSystem.timeSpeed);
                } else {
                    movingObjects.Remove(movingObjects[i]);
                }
            }
            for (int i = 0; i < movingObjects.Count; i++)
            {
                if (movingObjects[i] != null) {
                    movingObjects[i].UpdatePosition(Globals.timeStep, gameSystem.timeSpeed);
                } else {
                    movingObjects.Remove(movingObjects[i]);
                }
            }
        }
    }

    public void AddMovingObject(MovingObject movingObject) {
        if (!movingObjects.Contains(movingObject))
        {
            movingObjects.Add(movingObject);
        }
    }

    public void AdjustToTimeSpeed(float timeSpeedChange) {
        for (int i = 0; i < movingObjects.Count; i++) {
            if (movingObjects[i] != null) {
                movingObjects[i].AdjustVelocity(timeSpeedChange);
            } else {
                movingObjects.Remove(movingObjects[i]);
            }
        }
    }
}
