using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 initialVelocity;
    // private Vector2 initialVelocityAdjusted;
    // Vector2 currentVelocityGlobal;
    Vector2 currentVelocity;
    void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
    }
    public void UpdateVelocity(Planet[] allPlanets, float timeStep, float timeSpeed) {
        // Debug.Log(timeSpeed);
        foreach (Planet planet in allPlanets) {
            if (planet.rb != rb) {
                float sqrDist = (planet.rb.position - rb.position).sqrMagnitude;
                Vector2 forceDir = (planet.rb.position - rb.position).normalized;
                Vector2 acc = forceDir * Globals.G * timeSpeed * timeSpeed * planet.mass / sqrDist;
                currentVelocity += acc * timeStep;
                // currentVelocity = currentVelocityGlobal * timeSpeed;
            }
        }
    }

    public void UpdatePosition(float timeStep, float timeSpeed) {
        rb.position += currentVelocity * timeStep;
    }

    public void SetStartVelocity(float timeSpeed) {
        currentVelocity = initialVelocity * timeSpeed;
    }

    public void AdjustVelocity(float timeSpeedChange) {
        currentVelocity *= timeSpeedChange;
    }
}
