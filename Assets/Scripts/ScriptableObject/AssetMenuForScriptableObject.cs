using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item", menuName ="expvn/Create new item", order = 1)]
public class AssetMenuForScriptableObject : ScriptableObject
{
    public int id;
    public string nameItem;
    public string descriptionItem;
}
