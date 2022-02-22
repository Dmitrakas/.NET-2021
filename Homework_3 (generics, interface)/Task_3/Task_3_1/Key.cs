using System;

public readonly struct Key : IComparable<Key>
{
    public Octave Octave { get; }
    public Note Note { get; }
    public Accidental Accidental { get; }

    public Key(Note note, Accidental accidental = Accidental.Natural, Octave octave = Octave.First)
    {
        Note = CheckEnumValue(note, nameof(note));
        Accidental = CheckEnumValue(accidental, nameof(accidental));
        Octave = CheckEnumValue(octave, nameof(octave));

        const int minKeyNumber = -39;
        const int maxKeyNumber = 48;

        var keyNumber = GetKeyNumber();
        if (keyNumber < minKeyNumber || keyNumber > maxKeyNumber)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public bool Equals(Key other) => GetKeyNumber() == other.GetKeyNumber();

    public override bool Equals(object obj) => obj is Key key && Equals(key);

    public override int GetHashCode() => GetKeyNumber();

    public override string ToString() => Accidental switch
    {
        Accidental.Flat => $"{Note}b ({Octave})",
        Accidental.Sharp => $"{Note}# ({Octave})",
        _ => $"{Note} ({Octave})"
    };

    public int CompareTo(Key k) => GetKeyNumber() - k.GetKeyNumber();

    private int GetKeyNumber() => (int) Octave + (int) Note + (int) Accidental;

    private static TEnum CheckEnumValue<TEnum>(TEnum value, string paramName) where TEnum : Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
        {
            throw new ArgumentOutOfRangeException(paramName);
        }

        return value;
    }
}