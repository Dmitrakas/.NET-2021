using System;

Console.Write("Input array size (>=2) ");
var a = new int[int.Parse(Console.ReadLine())];
for (var i = 0; i < a.Length; i++)
{
    Console.Write($"Input element with index {i} = ");
    a[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Array:");
foreach (var item in a)
{
    Console.Write($"{item}\t");
}

Console.WriteLine();
int minIndex = 0, maxIndex = 0;
for (var i = 1; i < a.Length; i++)
{
    if (a[i] < a[minIndex])
    {
        minIndex = i;
    }
    else if (a[i] >= a[maxIndex])
    {
        maxIndex = i;
    }
}

if (minIndex > maxIndex)
{
    var temp = minIndex;
    minIndex = maxIndex;
    maxIndex = temp;
}

var sum = 0;
for (var i = minIndex; i <= maxIndex; i++)
{
    sum += a[i];
}

Console.WriteLine($"Sum: {sum}");