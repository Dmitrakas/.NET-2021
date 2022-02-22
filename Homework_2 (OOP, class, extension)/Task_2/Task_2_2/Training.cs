using System;

public class Training : Entity
{
    private Lesson[] _lessons = new Lesson[0];

    public void Add(Lesson lesson)
    {
        if (lesson == null)
        {
            return;
        }

        Array.Resize(ref _lessons, _lessons.Length + 1);
        _lessons[^1] = lesson;
    }

    public bool IsPractical()
    {
        if (_lessons.Length == 0)
        {
            return false;
        }

        foreach (var lesson in _lessons)
        {
            if (!(lesson is Practice))
            {
                return false;
            }
        }

        return true;
    }

    public Training Clone()
    {
        var training = new Training {Description = Description};
        training._lessons = new Lesson[_lessons.Length];
        for (var i = 0; i < _lessons.Length; i++)
        {
            training._lessons[i] = _lessons[i].Clone();
        }

        return training;
    }
}