using System.Collections;
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

    public void CheckObjectives()
    {
        Completed = Objectives.All(obj => obj.Compeleted);
        if (Completed) GiveRewardScore();
    }

    private void GiveRewardScore()
    {
        GameController.instance.AddScore(RewardScore);
    }
}
