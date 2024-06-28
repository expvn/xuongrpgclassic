using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Conversations : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textContent;
    public GameObject playerAvatar;
    public GameObject NPCAvatar;

    public GameObject conversationPanel;

    public List<HoiThoai> listHT = new List<HoiThoai>();

    public int current = 0;

    // Start is called before the first frame update
    private void Start()
    {
        LoadTextAsset("Map1/fox1");
        NoiChuyen();
    }

    public void LoadTextAsset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path); //Đọc file textAsset
        string[] lines = loadText.text.Split('\n'); //cắt dòng -> mỗi dòng là 1 phần tử

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split("\t"); //cắt tab -> mỗi tab 1 phần tử

            HoiThoai ht = new HoiThoai(); //tạo 1 hội thoại mới và gán các cột vào thuộc tính tương ứng
            ht.id = Convert.ToInt32(cols[0]);
            ht.character = cols[1];
            ht.content = cols[2];

            listHT.Add(ht); //Thêm hội thoại vào danh sách hội thoại
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        current++;
        NoiChuyen();
    }

    public void NoiChuyen()
    {
        if (current < listHT.Count)
        {
            if (listHT[current].character == "Player")
            {
                playerAvatar.SetActive(true);
                NPCAvatar.SetActive(false);
            }
            else
            {
                playerAvatar.SetActive(false);
                NPCAvatar.SetActive(true);
            }

            textContent.text = listHT[current].content;
        }
        else
        {
            current = 0;
            conversationPanel.SetActive(false);
        }
    }

    [System.Serializable]
    public class HoiThoai
    {
        public int id;
        public string character;
        public string content;
    }
}