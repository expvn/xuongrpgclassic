using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcDoiThoai : MonoBehaviour
{
    public Transform player;
    public DoiThoai doithoaiPanel;

    public void OnMouseDown()
    {
        if(Vector2.Distance(transform.position, player.position) < 2f)
        {
            doithoaiPanel.gameObject.SetActive(true);
            doithoaiPanel.LoadTextAsset("NPC");
            doithoaiPanel.NoiChuyen();
        }
    }
}
