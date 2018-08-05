using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "new Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public UnityEvent OnQuestStart;
    

    public string questName;
    public int questID;
    public string discription;
    public GameObject questGiver;


    private void Awake()
    {
        if(OnQuestStart == null)
        {
            OnQuestStart = new UnityEvent();
        }
    }

    public void QuestStart()
    {
        OnQuestStart.Invoke();
    }
    


}
