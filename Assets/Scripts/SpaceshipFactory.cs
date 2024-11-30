using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFactory : MonoBehaviour
{
    // public List<Spaceship> queue = new List<Spaceship>();
    public GameObject spaceshipPrefab;
    public GameSystem gameSystem;
    public DirectionSlider directionSlider;
    public Movement movement;

    // void Update() {
    //     if (Input.GetMouseButtonDown(0)) {
    //         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
    //         if (hit.collider != null && hit.collider.gameObject == this.gameObject) {
    //             Debug.Log("Clicked on: " + hit.collider.gameObject.name);
    //             CreateSpaceship(hit.collider.gameObject);
    //         }
    //     }
    // }

    public void CreateSpaceship(GameObject parent) {
        GameObject fullSpaceship = Instantiate(spaceshipPrefab, parent.transform);
        Spaceship spaceship = fullSpaceship.GetComponent<Spaceship>();
        spaceship.SetParent(parent);
        MovingObject spaceshipMoving = fullSpaceship.GetComponent<MovingObject>();
        float speed = 5f;
        Vector2 direction = directionSlider.GetDirection();
        spaceshipMoving.initialVelocity = direction * speed;
        spaceshipMoving.SetStartVelocity(gameSystem.timeSpeed);
        movement.AddMovingObject(spaceshipMoving);
    }


    // public Object CreateShip(GameObject spawn, GameObject target, float dayToArrive) {
    //     // Spaceship createdSpaceship = new Spaceship(spawn);
    //     Spaceship createdSpaceship = Instantiate(spaceship, spawn.transform).GetComponent<Spaceship>();
    //     createdSpaceship.SetTarget(target, dayToArrive);
    //     queue.Add(createdSpaceship);
    //     return createdSpaceship;
    // }
}
