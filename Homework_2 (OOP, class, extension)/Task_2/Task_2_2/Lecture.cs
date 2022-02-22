using System;

public class Lecture : Lesson
{
    public string Topic { get; set; }

    public override Lesson Clone() => new Lecture {Topic = Topic, Description = Description};

    public override string ToString() => $"Lecture: {Topic}{Environment.NewLine}{Description}";
}