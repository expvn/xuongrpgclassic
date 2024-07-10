using UnityEngine;

public class FoxNPC : MonoBehaviour
{
    public Transform player;
    public Conversations conversationPanel;

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, player.position) < 2f)
        {
            switch (QuestManager.instance.foxStory)
            {
                case 0:
                    {
                        conversationPanel.gameObject.SetActive(true);
                        conversationPanel.LoadTextAsset("Map1/fox1");
                        conversationPanel.idStory = 2;
                        conversationPanel.NoiChuyen();
                    }
                    break;

                case 1:
                    {
                        conversationPanel.gameObject.SetActive(true);
                        conversationPanel.LoadTextAsset("Map1/fox2");
                        conversationPanel.idStory = 0; //Không thay đổi tiến trình, chỉ thay đổi khi làm nhiệm vụ
                        conversationPanel.NoiChuyen();
                    }
                    break;
                case 2:
                    {
                        conversationPanel.gameObject.SetActive(true);
                        conversationPanel.LoadTextAsset("Map1/fox3");
                        conversationPanel.idStory = 2;
                        conversationPanel.NoiChuyen();
                    }
                    break;
            }
        }
    } 
}