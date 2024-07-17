using System;
using System.Collections.Generic;
using UnityEngine;

public class ListItem : MonoBehaviour
{
    public static ListItem Instance;

    public List<Sprite> list;
    public List<ItemInfo> allItem;
    public List<Items> listPlayerItem;

    private void Awake()
    {
        Instance = this;

        TextAsset load = Resources.Load<TextAsset>("allItem");
        string[] lines = load.text.Split('\n'); //cắt dòng -> mỗi dòng là 1 phần tử

        allItem = new List<ItemInfo>();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            ItemInfo item = new ItemInfo();
            item.id = i;
            item.name = cols[1];
            item.description = cols[2];
            item.icon = list[i - 1];
            item.type = Convert.ToInt32(cols[4]);
            item.rare = Convert.ToInt32(cols[5]);

            allItem.Add(item);
        }
    }

    private void Start()
    {
        foreach (var x in ListItem.Instance.allItem)
        {
            Items i = new Items();
            i.itemInfo = x;
            listPlayerItem.Add(i);
        }
    }
}

[System.Serializable]
public class Items
{
    public ItemInfo itemInfo;
    public ItemAttribute attribute1;
    public ItemAttribute attribute2;
    public ItemAttribute attribute3;
}

[System.Serializable]
public class ItemInfo
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public int type; //1 - VK, 2 - Mũ, 3 - Dây chuyển, 4 - Nhẫn, 5 - Khác
    public int rare; //độ hiếm
}

[System.Serializable]
public class ItemAttribute
{
    public int id; //id thuộc tính. ví dụ 1 là tăng str
    public string name; //tên của thuộc tính
    public int value; //giá trị của thuộc tính
    public int type; //1 là + % - 2 là + điểm
}