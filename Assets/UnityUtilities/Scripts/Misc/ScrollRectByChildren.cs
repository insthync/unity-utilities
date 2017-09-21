using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectByChildren : MonoBehaviour, 
    IBeginDragHandler, 
    IDragHandler, 
    IEndDragHandler, 
    IScrollHandler
{
    public ScrollRect scrollRect;
    private void Awake()
    {
        if (scrollRect == null)
            scrollRect = GetComponentInParent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (scrollRect != null)
            scrollRect.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (scrollRect != null)
            scrollRect.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (scrollRect != null)
            scrollRect.OnEndDrag(eventData);
    }

    public void OnScroll(PointerEventData data)
    {
        if (scrollRect != null)
            scrollRect.OnScroll(data);
    }
}
