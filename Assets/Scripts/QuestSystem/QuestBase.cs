using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestBase : MonoBehaviour
{
    public List<Objective> Objectives { get; set; } = new List<Objective>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int RewardScore { get; set; }
    public int PunishScore { get; set; }
    public float QuestTime { get; set; }
    public float TimeLeft { get; set; }
    private GameObject QuestUI { get; set; }
    private QuestUISetUp QuestUISetter { get; set; }

    private void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        TimeLeft = QuestTime;

        GameObject questPanel = GameObject.Find("QuestPanel");
        QuestUI = Instantiate((GameObject)Resources.Load("Prefabs/UI/Quest_UI"), questPanel.transform);
        QuestUISetter = QuestUI.GetComponent<QuestUISetUp>();
        QuestUISetter.UISetup(QuestName, Description, QuestTime);
    }

    private void Update()
    {
        CountDown();
    }

    public void CheckObjectives()
    {
        Completed = Objectives.All(obj => obj.Compeleted);
        if (Completed) QuestCompleted();
    }

    public void QuestFailed()
    {
        Punishment();
        EndQuest();
    }

    public void QuestCompleted()
    {
        GiveRewardScore();
        EndQuest();
    }

    private void GiveRewardScore()
    {
        GameController.instance.AddScore(RewardScore);
    }

    private void Punishment()
    {
        GameController.instance.DecreaseScore(RewardScore);
    }

    private void CountDown()
    {
        TimeLeft -= Time.deltaTime;
        QuestUISetter.TimeRefresh(TimeLeft);

        if (TimeLeft <= 0.0f)
        {
            QuestFailed();
        }
    }

    private void EndQuest()
    {
        Destroy(QuestUI);
        Destroy(this.gameObject);
    }
}