using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour, IPointerClickHandler
{
    public Items item;
    public Image icon;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log(item.itemsInfo.name);
        }
    }

    public void SetIcon()
    {
        if (item != null)
        {
            icon.sprite = item.itemsInfo.sprite;
            icon.color = new Color(1, 1, 1, 1);
        }
    }

    public void SetHide()
    {
        icon.color = new Color(1, 1, 1, 0);
    }
}