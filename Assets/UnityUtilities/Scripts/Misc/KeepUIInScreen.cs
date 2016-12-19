using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class KeepUIInScreen : MonoBehaviour
{
    public Vector2 screenPadding = new Vector2(10, 10);
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        Rect transformRect = rectTransform.rect;

        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // ui rect to world space
        Vector2 worldSpaceRectMin = rectTransform.TransformPoint(transformRect.min);
        Vector2 worldSpaceRectMax = rectTransform.TransformPoint(transformRect.max);
        // Find rect size by max - min
        Vector2 worldSpaceSize = worldSpaceRectMax - worldSpaceRectMin;

        // keep the min position in screen bounds - size
        Vector3 worldSpaceUIRectMin = screenPadding;
        Vector2 worldSpaceUIRectMax = screenSize - worldSpaceSize - screenPadding;

        // keep pos between (min screen position) and (screen size - ui size)
        var x = worldSpaceRectMin.x;
        var y = worldSpaceRectMin.y;

        if (x < worldSpaceUIRectMin.x)
            x = worldSpaceUIRectMin.x;
        else if (x > worldSpaceUIRectMax.x)
            x = worldSpaceUIRectMax.x;

        if (y < worldSpaceUIRectMin.y)
            y = worldSpaceUIRectMin.y;
        else if (y > worldSpaceUIRectMax.y)
            y = worldSpaceUIRectMax.y;

        // find pivot offset
        Vector2 pivotOffset = (Vector2)rectTransform.position - worldSpaceRectMin;

        // set the new position + pivot offset
        rectTransform.position = new Vector2(x, y) + pivotOffset;
    }
}
