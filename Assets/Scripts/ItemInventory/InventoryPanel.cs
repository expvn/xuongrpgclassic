using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public Transform slotParent;
    public List<SlotItem> listSlot;

    private void Start()
    {
        foreach (Transform t in slotParent)
        {
            listSlot.Add(t.GetComponent<SlotItem>());
        }
        print("start");
        ShowItem();
    }

    public void ShowItem()
    {
        print(ListItem.Instance.listPlayerItem.Count);
        for (int i = 0; i < ListItem.Instance.listPlayerItem.Count; i++)
        {
            print(ListItem.Instance.listPlayerItem[i].itemInfo.name);
            listSlot[i].item = ListItem.Instance.listPlayerItem[i];
            listSlot[i].SetIcon();
        }
    }
}