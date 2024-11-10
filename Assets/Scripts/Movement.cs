using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Planet[] planets;
    void Awake()
    {
        planets = FindObjectsByType<Planet>(FindObjectsSortMode.None);
        Time.fixedDeltaTime = Globals.timeStep;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < planets.Length; i++) {
            planets[i].UpdateVelocity(planets, Globals.timeStep);
        }
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].UpdatePosition(Globals.timeStep);
        }
    }

    void DrawLine() {
        
    }
}
