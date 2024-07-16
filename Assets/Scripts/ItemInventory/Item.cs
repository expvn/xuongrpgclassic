using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    [TextArea] public string description;
    public Sprite icon;
    public int type; //1 = vk, 2 = ao, 3 = day chuyen, 4 = nhan
    public int rare; //độ hiếm 1 - thường, 2 - hiếm, 3 - cực hiếm
    public Attributes attributes;
}
