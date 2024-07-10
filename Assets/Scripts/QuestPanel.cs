using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    public Quest quest;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI expText;
    public int brandID;

    public void ShowQuest(Quest q, int id)
    {
        quest = q;
        title.text = quest.name;
        description.text = quest.description;
        coinText.text = quest.coinReward.ToString();
        expText.text = quest.xpReward.ToString();
        brandID = id;
    }

    public void OKBTN()
    {
        QuestManager.instance.receivedQuest.Add(quest);
        gameObject.SetActive(false);
    }

    public void CancelBTN()
    {
        QuestManager.instance.BackQip(brandID);
        gameObject.SetActive(false);
    }
}
