using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotItem : MonoBehaviour, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Canvas parent;
    public Canvas child;
    public RectTransform rectTransform;

    public void OnBeginDrag(PointerEventData eventData)
    {
        child.overrideSorting = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / parent.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        child.overrideSorting = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("show info");
    }
}
