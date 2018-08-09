using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUISetUp : MonoBehaviour
{
    public Text questTitle;
    public Text questDescription;
    public Text questTime;

    public void UISetup(string title, string description, float time)
    {
        this.gameObject.name = "quest_" + title;
        questTitle.text = title;
        questDescription.text = description;
        questTime.text = time.ToString();
    }


    public void TimeRefresh(float time)
    {
        questTime.text = time.ToString();
    }
}
