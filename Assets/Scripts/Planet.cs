using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float mass;
    [SerializeField] public float radius;
    [SerializeField] public Vector2 initialVelocity;
    Vector2 currentVelocity;
    void Awake()
    {
        currentVelocity = initialVelocity;
    }

    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // public void UpdateVelocity(Planet[] allPlanets, float timeStep) {
    //     foreach (Planet planet in allPlanets) {
    //         if (planet != this) {
    //             float sqrDist = (planet.rb.position - rb.position).sqrMagnitude;
    //             Vector2 forceDir = (planet.rb.position - rb.position).normalized;
    //             Vector2 force = forceDir * Globals.G * mass * planet.mass / sqrDist;
    //             Vector2 acc = force / mass;
    //             currentVelocity += acc * timeStep;
    //         }
    //     }
    // }

    // public void UpdatePosition(float timeStep) {
    //     rb.position += currentVelocity * timeStep;
    // }
}
