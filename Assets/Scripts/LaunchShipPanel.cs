using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaunchShipPanel : MonoBehaviour
{
    public GameObject parentPlanet;
    public SpaceshipFactory spaceshipFactory;
    public DirectionSlider directionSlider;
    public LineRenderer lineRenderer;
    void Start()
    {
        spaceshipFactory = this.GetComponent<SpaceshipFactory>();
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (parentPlanet) {
            DrawDirection();
        }
    }

    public void PanelToShip() {
        spaceshipFactory.CreateSpaceship(parentPlanet);
    }

    public void OpenPanel(GameObject planet) {
        parentPlanet = planet;
        TextMeshProUGUI text = this.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "Clicked on " + planet.name;
    }

    void DrawDirection() {
        Vector2 direction = directionSlider.GetDirection();
        Debug.Log(direction);
        lineRenderer.SetPosition(0, (Vector2)parentPlanet.transform.position);
        lineRenderer.SetPosition(1, (Vector2)parentPlanet.transform.position + direction * 5);
        // Debug.DrawLine((Vector2)parentPlanet.transform.position, direction * 20, Color.white);
        Debug.Log("Line drawn");
    }
}
