using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "new Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public enum QUESTSTATE
    {
        ACTIVE,
        COMPLETE,
        FAILED
    };

    public UnityEvent OnQuestStart;
    public UnityEvent OnQuestComplete;

    public QuestBuilder questBuilder;

    public string questName;
    public int questID;
    [TextArea]
    public string discription;
    public QUESTSTATE questState;
    public GameObject questGiver;
    public int questSteps;
    public bool[] stepcount;
    public int score;


    private void Awake()
    {
        if (OnQuestStart == null)
        {
            OnQuestStart = new UnityEvent();
        }
        if (OnQuestComplete == null)
        {
            OnQuestComplete = new UnityEvent();
        }

        for(int i = 0; i < questSteps; ++i)
        {
            stepcount[i] = false;
        }
    }

    public void QuestStart()
    {
        OnQuestStart.Invoke();
    }

    public void QuestComplete()
    {
        OnQuestComplete.Invoke();
    }

}
