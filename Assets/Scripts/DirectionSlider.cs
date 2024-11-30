using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DirectionSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform handle;
    public Image background;
    public float radiusBackground = 50f;
    public float radiusHandle = 10f;

    private Vector2 center;
    private bool isDragging = false;

    void Start()
    {
        center = background.rectTransform.position;
        // UpdateHandlePosition(Vector2.zero);
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (isDragging && Input.GetMouseButton(0))
        {
            Vector2 direction = mousePosition - center;
            direction = direction.normalized;

            Vector2 handlePosition = center + direction * (radiusBackground - radiusHandle);

            UpdateHandlePosition(handlePosition);
        }
    }

    void UpdateHandlePosition(Vector2 position)
    {
        handle.position = position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Check if the click was within the bounds of the background circle
        // if (RectTransformUtility.RectangleContainsScreenPoint(handle, eventData.position, eventData.enterEventCamera))
        // {
            isDragging = true;  // Start dragging if the pointer is over the handle
        // }
    }

    // Method to stop dragging when the user releases the mouse button
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;  // Stop dragging
    }

    public Vector2 GetDirection()
    {
        Vector2 direction = (Vector2)handle.position - center;
        return direction.normalized;
    }
}
