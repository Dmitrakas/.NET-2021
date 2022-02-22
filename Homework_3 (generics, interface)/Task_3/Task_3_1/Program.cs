using System;

var c = new Key(Note.C, Accidental.Sharp);
Console.WriteLine(c.Note);
Console.WriteLine(c.Accidental);
Console.WriteLine(c.Octave);
Console.WriteLine(c);
Console.ReadLine();

var d = new Key(Note.D, Accidental.Flat);
Console.WriteLine(d.Note);
Console.WriteLine(d.Accidental);
Console.WriteLine(d.Octave);
Console.WriteLine(d);
Console.ReadLine();

Console.WriteLine(c.Equals(d));
Console.WriteLine(c.CompareTo(d));
Console.ReadLine();

var x = new Key(Note.C, Accidental.Flat);
Console.WriteLine(x.Note);
Console.WriteLine(x.Accidental);
Console.WriteLine(x.Octave);
Console.WriteLine(x);
Console.ReadLine();

var y = new Key(Note.B, Accidental.Natural, Octave.Small);
Console.WriteLine(y.Note);
Console.WriteLine(y.Accidental);
Console.WriteLine(y.Octave);
Console.WriteLine(y);
Console.ReadLine();

Console.WriteLine(x.Equals(y)); 
Console.WriteLine(x.CompareTo(c)); 
Console.ReadLine();

var defaultKey = new Key();
Console.WriteLine(defaultKey);
Console.ReadLine();
