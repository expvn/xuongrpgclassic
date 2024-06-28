using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxNPC : MonoBehaviour
{
    public Transform player;
    public GameObject conversationPanel;

    private void OnMouseDown()
    {
        if(Vector2.Distance(transform.position, player.position) < 2f)
        {
            conversationPanel.SetActive(true);
        }
    }
}
