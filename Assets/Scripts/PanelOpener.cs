using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public LaunchShipPanel launchShipPanel;
    public HitText hitText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Planet>() != null && hit.collider.gameObject.name != "Sun" /* && hit.collider.gameObject == this.gameObject */) {
                // LaunchShipPanel launchShipPanel = Instantiate(panelPrefab, canvas.transform).GetComponent<LaunchShipPanel>();
                launchShipPanel.gameObject.SetActive(true);
                launchShipPanel.OpenPanel(hit.collider.gameObject);
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);
            }
        }
    }
}
