using UnityEngine;
using UnityEngine.EventSystems;

public class MobileMovementJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public int movementRange = 150;
    public bool useAxisX = true;
    public bool useAxisY = true;
    public string axisXName = "Horizontal";
    public string axisYName = "Vertical";
    [Tooltip("Container which showing as area that able to control movement")]
    public RectTransform movementBackground;
    [Tooltip("This is the button to control movement")]
    public RectTransform movementController;
    private Vector3 backgroundOffset;
    private Vector3 defaultControllerPosition;
    private Vector3 startDragPosition;

    private void Start()
    {
        if (movementBackground != null)
            backgroundOffset = movementBackground.position - movementController.position;
        defaultControllerPosition = movementController.position;
    }

    public void OnPointerDown(PointerEventData data)
    {
        movementController.position = new Vector3(data.position.x, data.position.y, transform.position.z);
        if (movementBackground != null)
            movementBackground.position = backgroundOffset + movementController.position;
        startDragPosition = movementController.position;
    }

    public void OnPointerUp(PointerEventData data)
    {
        movementController.position = defaultControllerPosition;
        if (movementBackground != null)
            movementBackground.position = backgroundOffset + movementController.position;

        if (useAxisX)
            InputManager.SetAxis(axisXName, 0);

        if (useAxisY)
            InputManager.SetAxis(axisYName, 0);
    }

    public void OnDrag(PointerEventData data)
    {
        Vector3 newPos = Vector3.zero;

        var allowedPos = new Vector3(data.position.x, data.position.y, 0) - startDragPosition;
        allowedPos = Vector3.ClampMagnitude(allowedPos, movementRange);

        if (useAxisX)
            newPos.x = allowedPos.x;

        if (useAxisY)
            newPos.y = allowedPos.y;

        movementController.position = new Vector3(startDragPosition.x + newPos.x, startDragPosition.y + newPos.y, startDragPosition.z + newPos.z);
        UpdateVirtualAxes(movementController.position);
    }

    private void UpdateVirtualAxes(Vector3 value)
    {
        var delta = startDragPosition - value;
        delta.y = -delta.y;
        delta /= movementRange;
        if (useAxisX)
            InputManager.SetAxis(axisXName, -delta.x);

        if (useAxisY)
            InputManager.SetAxis(axisYName, delta.y);
    }
}
