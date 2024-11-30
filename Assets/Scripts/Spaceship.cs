using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 initialVelocity;
    public bool isFlying = false;
    public HitText hitText;
    private Vector2 currentVelocity;
    private GameObject parent;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        PanelOpener panelOpener = GameObject.Find("GameSystem").GetComponent<PanelOpener>();
        hitText = panelOpener.hitText;
    }

    void FixedUpdate() {
        if (Mathf.Abs(transform.position.x) > 100 || Mathf.Abs(transform.position.y) > 100) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != parent) {
            hitText.UpdateText("Hit " + other.gameObject.name);
            Destroy(this.gameObject);
        }
    }

    public void SetParent(GameObject parentToSet) {
        parent = parentToSet;
    }

    // public void StartFlying() {
    //     currentVelocity = initialVelocity;
    //     isFlying = true;
    // }


    // public void UpdateVelocity(Planet[] allPlanets, float timeStep) {
    //     foreach (Planet planet in allPlanets) {
    //         float sqrDist = (planet.rb.position - rb.position).sqrMagnitude;
    //         Vector2 forceDir = (planet.rb.position - rb.position).normalized;
    //         Vector2 acc = forceDir * Globals.G * planet.mass / sqrDist;
    //         currentVelocity += acc * timeStep;
    //     }
    //     Debug.Log(currentVelocity);
    // }

    // public void UpdatePosition(float timeStep) {
    //     rb.position += currentVelocity * timeStep;
    // }
}
