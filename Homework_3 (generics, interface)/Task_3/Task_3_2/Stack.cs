using System;

public class Stack<T> : IStack<T> where T : struct
{
    private const int MaxStackSize = 1000;

    private readonly T[] _items = new T[MaxStackSize];
    private int _index = -1;

    public void Push(T item)
    {
        if (_index == MaxStackSize)
        {
            throw new StackOverflowException();
        }

        _items[++_index] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return _items[_index--];
    }

    public bool IsEmpty() => _index == -1;

    public override string ToString()
    {
        if (IsEmpty())
        {
            return "Empty";
        }

        var result = string.Empty;
        for (var i = _index; i >= 0; i--)
        {
            result += _items[i] + Environment.NewLine;
        }

        return result;
    }
}