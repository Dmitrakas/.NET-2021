using System;

var m = new DiagonalMatrix(1, 3, 5);
Console.WriteLine(m);
Console.WriteLine($"Track is {m.Track()}");

var p = new DiagonalMatrix(2, 2, 2, 3);
var sum = m.Add(p);

Console.WriteLine(sum);