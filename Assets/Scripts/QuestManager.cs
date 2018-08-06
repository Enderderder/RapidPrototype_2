using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Singleton Instance
    public static QuestManager instance;

    // Quest Lists
    public List<Quest> possibleQuestList;
    public List<Quest> activeQuestList;

	void Awake ()
    {  
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }



}
