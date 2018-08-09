using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Singleton Instance
    public static QuestManager instance;

    // Quest Holder Object
    private GameObject questHolderObj;

    [Header("Quest Collection")]
    // Quest Lists
    public string[] questName;

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

    

    public void CreateRandomQuest()
    {

    }


}
