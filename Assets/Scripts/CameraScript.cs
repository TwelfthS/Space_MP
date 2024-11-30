using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public RectTransform window;
    private Camera camera;
    private float zoomSpeed = 15.0f;
    private float minSize = 2f;
    private float maxSize = 1000f;
    private float panSpeed = 0.05f;

    private bool isPanning = false;
    private Vector3 lastMousePosition;

    void Start() {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        camera.orthographicSize -= scroll * zoomSpeed;
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minSize, maxSize);
        if (Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(window, Input.mousePosition)) {
            isPanning = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && isPanning) {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x * panSpeed, -delta.y * panSpeed, 0);
            transform.Translate(move, Space.World);
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            isPanning = false;
        }
    }
}
