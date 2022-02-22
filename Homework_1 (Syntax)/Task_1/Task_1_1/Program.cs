using System;

Console.Write("Input a = ");
var a = int.Parse(Console.ReadLine());
Console.Write("Input b = ");
var b = int.Parse(Console.ReadLine());
if (a > b)
{
    var temp = a;
    a = b;
    b = temp;
}

for (var number = a; number <= b; number++)
{
    var count = 0;
    for (var i = number > 0 ? number : -number; i > 0; i /= 3)
    {
        if (i % 3 == 2)
        {
            count++;
        }
    }

    if (count == 2)
    {
        Console.WriteLine(number);
    }
}