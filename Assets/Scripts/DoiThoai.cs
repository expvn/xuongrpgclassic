using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoiThoai : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textContent;
    public GameObject playerAvatar;
    public GameObject NPCAvatar;

    public List<HT> listHT;
    public int current = 0;
    public void LoadTextAsset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');

        listHT = new List<HT>();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');
            HT hT = new HT();
            hT.id = Convert.ToInt32(cols[0]);
            hT.character = cols[1];
            hT.content = cols[2];

            listHT.Add(hT);
        }
        current = 0;
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
            //kết thúc
            //Giao nhiệm vụ (nếu có)
            //truyền đi nhiệm vụ
            //Tắt giao diện nói chuyện
            gameObject.SetActive(false);
        }
    }
}

[System.Serializable]
public class HT
{
    public int id;
    public string character;
    public string content;
}
