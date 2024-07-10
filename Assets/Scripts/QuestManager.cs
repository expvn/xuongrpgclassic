using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> AllQuests = new List<Quest>();
    public List<Quest> receivedQuest = new List<Quest>();
    public List<BrandStoryID> brandStory = new List<BrandStoryID>();

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

        brandStory.Add(new BrandStoryID { brandID = 1, name = "mainStory", qip = 0 });
        brandStory.Add(new BrandStoryID { brandID = 2, name = "foxStory", qip = 0 });
    }

    public void LoadTextAsset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path); //Đọc file textAsset
        string[] lines = loadText.text.Split('\n'); //cắt dòng -> mỗi dòng là 1 phần tử

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split("\t"); //cắt tab -> mỗi tab 1 phần tử

            Quest q = new Quest();
            q.brandStoryID = System.Convert.ToInt32(cols[0]);
            q.qip = System.Convert.ToInt32(cols[1]);
            q.name = cols[2];
            q.description = cols[3];
            q.xpReward = System.Convert.ToInt32(cols[4]);
            q.coinReward = System.Convert.ToInt32(cols[5]);
            q.requiment = System.Convert.ToInt32(cols[6]);

            AllQuests.Add(q); //Thêm hội thoại vào danh sách hội thoại
        }
    }

    public void SetQipStory(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            getQip.qip++;
        }
    }

    public int GetQipStory(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            return getQip.qip;
        }
        else
        {
            return 0;
        }
    }

    public void BackQip(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            getQip.qip--;
        }
    }

    public Quest GetQuest(int id)
    {
        var qip = GetQipStory(id);
        var getQ = AllQuests.FirstOrDefault(x => x.brandStoryID == id && x.qip == qip);
        if (getQ != null)
        {
            return getQ;
        }
        else
        {
            return null;
        }
    }
}

[System.Serializable]
public class BrandStoryID
{
    public int brandID;
    public string name;
    public int qip; //quest in progresss
}

[System.Serializable]
public class Quest
{
    public int brandStoryID;
    public int qip; //Quest in progress
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
            var getQip = QuestManager.instance.brandStory.FirstOrDefault(x => x.brandID == brandStoryID);
            if (getQip != null)
            {
                getQip.qip++;
            }
        }
    }
}