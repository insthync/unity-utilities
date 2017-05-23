using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///     Adding this script to UI elements makes them draggable
///     Based on Barebone Masterserver - Draggable script
/// </summary>
public class UIDraggable : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup _group;
    private RectTransform _rectTransform;
    private float _offsetY;
    private float _offsetX;

    public bool KeepInScreen = true;
    public bool SetAsLastSiblingOnDrag = true;
    public bool SetAsLastSiblingOnEnable = true;
    public bool ChangeOpacity = true;
    public float DraggedOpacity = 0.7f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SetAsLastSiblingOnDrag)
            transform.SetAsLastSibling();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _offsetX = transform.position.x - Input.mousePosition.x;
        _offsetY = transform.position.y - Input.mousePosition.y;

        if (_group != null)
            _group.alpha = DraggedOpacity;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(_offsetX + Input.mousePosition.x, _offsetY + Input.mousePosition.y);
        if (SetAsLastSiblingOnDrag)
            transform.SetAsLastSibling();
        UpdateKeepInScreen();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_group != null)
            _group.alpha = 1f;
        UpdateKeepInScreen();
    }

    public void UpdateKeepInScreen()
    {
        if (!KeepInScreen)
            return;

        var oldPosition = transform.position;
        // Keeping ui in screen
        var screenSize = new Vector3(Screen.width, Screen.height);
        Rect transformRect = _rectTransform.rect;
        var worldSpaceRectMin = _rectTransform.TransformPoint(transformRect.min);
        var worldSpaceRectMax = _rectTransform.TransformPoint(transformRect.max);
        var moveableMax = screenSize - (worldSpaceRectMax - worldSpaceRectMin);

        var x = worldSpaceRectMin.x;
        var y = worldSpaceRectMin.y;

        if (x < 0)
            x = 0;
        else if (x > moveableMax.x)
            x = moveableMax.x;

        if (y < 0)
            y = 0;
        else if (y > moveableMax.y)
            y = moveableMax.y;

        transform.position = new Vector3(x, y, 0) + oldPosition - worldSpaceRectMin;
    }

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        if (SetAsLastSiblingOnEnable)
            transform.SetAsLastSibling();
    }
}
