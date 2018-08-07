

public class Objective
{
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
            Compeleted = true;
        }
    }
}