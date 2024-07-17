using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour, IPointerClickHandler
{
    public Items item;
    public Image icon;

    public void SetIcon()
    {
        icon.sprite = item.itemInfo.icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(item.itemInfo.name);
    }
}
