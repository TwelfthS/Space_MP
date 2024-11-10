using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaunchShipPanel : MonoBehaviour
{
    public GameObject parentPlanet;
    public SpaceshipFactory spaceshipFactory;
    void Start()
    {
        spaceshipFactory = this.GetComponent<SpaceshipFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0)) {
        //     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        //     if (hit.collider != null /* && hit.collider.gameObject == this.gameObject */) {
        //         OpenPanel(hit.collider.gameObject);
        //         Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                
        //     }
        // }
    }

    public void PanelToShip() {
        spaceshipFactory.CreateSpaceship(parentPlanet);
    }

    public void OpenPanel(GameObject planet) {
        parentPlanet = planet;
        TextMeshProUGUI text = this.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "Clicked on " + planet.name;
    }
}
