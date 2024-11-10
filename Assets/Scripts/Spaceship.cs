using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 initialVelocity;
    public bool isFlying = false;
    private Vector2 currentVelocity;
    Planet[] planets;
    void Awake()
    {
        planets = FindObjectsByType<Planet>(FindObjectsSortMode.None);
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (isFlying) {
            UpdateVelocity(planets, Globals.timeStep);
            UpdatePosition(Globals.timeStep);
            if (Mathf.Abs(transform.position.x) > 100 || Mathf.Abs(transform.position.y) > 100) {
                Destroy(this.gameObject);
            }
        }
    }

    public void StartFlying() {
        currentVelocity = initialVelocity;
        isFlying = true;
    }


    public void UpdateVelocity(Planet[] allPlanets, float timeStep) {
        foreach (Planet planet in allPlanets) {
            float sqrDist = (planet.rb.position - rb.position).sqrMagnitude;
            Vector2 forceDir = (planet.rb.position - rb.position).normalized;
            Vector2 acc = forceDir * Globals.G * planet.mass / sqrDist;
            currentVelocity += acc * timeStep;
        }
        Debug.Log(currentVelocity);
    }

    public void UpdatePosition(float timeStep) {
        rb.position += currentVelocity * timeStep;
    }

//     public void SetTarget(GameObject planet, float arriveDay) {
//         destination = CalculateDestination(planet, arriveDay);
//     }

//     public Vector2 CalculateDestination(GameObject planet, float arriveDay) {
//         Vector2 currentTargetPos = planet.transform.position;
//         Planet dest = planet.GetComponent<Planet>();
//         float angle = dest.speed * (arriveDay - GameSystem.Instance.currentDay) / dest.r;
//         Vector2 expectedTargetPos = new Vector2(Mathf.Cos(angle) * dest.r, Mathf.Sin(angle) * dest.r);
//         Debug.Log(expectedTargetPos);
//         return expectedTargetPos;
//     }

//     // public float CalculateStartDay() {
//     //     Vector2 currentTargetPos = target.transform.position;
//     //     Planet dest = target.GetComponent<Planet>();
//     //     Planet spwn = spawn.GetComponent<Planet>();
//     //     float angle = dest.speed * Time.deltaTime * (arriveDay - GameSystem.Instance.currentDay) / dest.r;
//     //     Vector2 expectedTargetPos = new Vector2(Mathf.Cos(angle) * dest.r, Mathf.Sin(angle) * dest.r);
//     //     float angle2 = spwn.speed * Time.deltaTime * (arriveDay - GameSystem.Instance.currentDay) / spwn.r;
//     //     Vector2 expectedSpawnPos = new Vector2(Mathf.Cos(angle2) * spwn.r, Mathf.Sin(angle2) * spwn.r);
//     //     return 1;
//     // }

//     void MoveToTarget() {
//         float step =  speed * Time.deltaTime;
//         transform.position = Vector3.MoveTowards(transform.position, destination, step);

//         if (Vector3.Distance(transform.position, destination) < 0.001f)
//         {
//             Destroy(this.gameObject);
//         }
//     }
}
