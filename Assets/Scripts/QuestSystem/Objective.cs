

public class Objective
{
    public QuestBase Quest { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Compeleted { get; set; }
    public int CurrentCount { get; set; }
    public int TotalCount { get; set; }
	
    public virtual void Init()
    {
        // Base class Init
    }

    public void Evaluate()
    {
        if (CurrentCount >= TotalCount)
        {
            Completed();
        }
    }

    private void Completed()
    {
        Compeleted = true;
        this.Quest.CheckObjectives();
    }
}