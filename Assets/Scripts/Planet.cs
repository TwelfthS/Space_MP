using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cl;
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
        cl = this.GetComponent<Collider2D>();
    }

    // void Update() {
    //     if (Input.GetMouseButtonDown(0)) {
    //         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
    //         if (hit.collider == cl) {
    //             Debug.Log("Clicked on: " + hit.collider.gameObject.name);
    //             SpaceshipFactory.CreateSpaceship(this.gameObject);
    //         }
    //     }
    // }

    public void UpdateVelocity(Planet[] allPlanets, float timeStep) {
        foreach (Planet planet in allPlanets) {
            if (planet != this) {
                float sqrDist = (planet.rb.position - rb.position).sqrMagnitude;
                Vector2 forceDir = (planet.rb.position - rb.position).normalized;
                Vector2 force = forceDir * Globals.G * mass * planet.mass / sqrDist;
                Vector2 acc = force / mass;
                currentVelocity += acc * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep) {
        rb.position += currentVelocity * timeStep;
    }

    // void Update()
    // {
    //     transform.position = calcNextPosition(transform.position);
    // }

    // Vector2 calcNextPosition(Vector2 pos) {
    //     angle += speed * Time.deltaTime / r;
    //     float x = Mathf.Cos(angle) * r;
    //     float y = Mathf.Sin(angle) * r;
    //     return new Vector2(x, y);
    // }
}
