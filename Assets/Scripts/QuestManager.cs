using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public int mainStory = 0;
    public int foxStory = 0;
    public List<Quest> AllQuests = new List<Quest>();
    public List<Quest> receivedQuest = new List<Quest>();

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        LoadTextAsset("Map1/subQuest");
    }

    public void LoadTextAsset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path); //Đọc file textAsset
        string[] lines = loadText.text.Split('\n'); //cắt dòng -> mỗi dòng là 1 phần tử

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split("\t"); //cắt tab -> mỗi tab 1 phần tử

            Quest q = new Quest();
            q.id = System.Convert.ToInt32(cols[0]);
            q.progressStory = System.Convert.ToInt32(cols[1]);
            q.name = cols[2];
            q.description = cols[3];
            q.xpReward = System.Convert.ToInt32(cols[4]);
            q.coinReward = System.Convert.ToInt32(cols[5]);
            q.requiment = System.Convert.ToInt32(cols[6]);

            AllQuests.Add(q); //Thêm hội thoại vào danh sách hội thoại
        }
    }

    public void SetProgressQuestStory(int idStory)
    {
        switch (idStory)
        {
            case 1: mainStory++; break;
            case 2: foxStory++; break;
        }
    }

    public Quest CheckQuest(int idStory)
    {
        if (idStory == 2 && foxStory == 2)
        {
            var getQ = AllQuests.FirstOrDefault(x => x.id == idStory && x.progressStory == foxStory);
            if (getQ != null)
            {
                return getQ;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}

[System.Serializable]
public class Quest
{
    public int id;
    public int progressStory;
    public string name;
    public string description;
    public int xpReward;
    public int coinReward;
    public int requiment;
    public int current;
    public bool complete;

    public void SetCurrent()
    {
        current++;
        if (current >= requiment)
        {
            complete = true;
        }
    }
}