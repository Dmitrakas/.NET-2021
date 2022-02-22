using System;

public class Practice : Lesson
{
    public string Task { get; set; }
    public string Solution { get; set; }

    public override Lesson Clone() => new Practice {Task = Task, Solution = Solution, Description = Description};

    public override string ToString() => $"Task: {Task}{Environment.NewLine}Solution: {Solution}";
}