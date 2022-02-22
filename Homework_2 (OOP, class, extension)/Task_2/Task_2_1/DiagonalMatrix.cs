using System;

public class DiagonalMatrix
{
    private readonly int[] _data;

    public int Size => _data.Length;

    public int this[int i, int j]
    {
        get => i == j && IsCorrect(i) ? _data[i] : 0;
        set
        {
            if (i == j && IsCorrect(i))
            {
                _data[i] = value;
            }
        }
    }

    public DiagonalMatrix(params int[] data)
    {
        if (data == null)
        {
            _data = new int[0];
        }
        else
        {
            _data = new int[data.Length];
            data.CopyTo(_data, 0);
        }
    }

    public int Track()
    {
        var sum = 0;
        foreach (var item in _data)
        {
            sum += item;
        }

        return sum;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is DiagonalMatrix m) || Size != m.Size)
        {
            return false;
        }

        for (var i = 0; i < _data.Length; i++)
        {
            if (_data[i] != m._data[i])
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        var code = _data.Length;
        foreach (var item in _data)
        {
            code = unchecked(code * 17 + item);
        }

        return code;
    }

    public override string ToString()
    {
        var result = string.Empty;
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                result += $"{this[i, j],-10}";
            }

            result += Environment.NewLine;
        }

        return result;
    }

    private bool IsCorrect(int i) => i >= 0 && i < Size;
}