using System;

Console.Write("Input 9-digit number ");
var isbn = Console.ReadLine();
var number = int.Parse(isbn);

var sum = 0;
for (var i = 2; i <= 10; i++)
{
    var digit = number % 10;
    number /= 10;
    sum += i * digit;
}

var last = (11 - sum % 11) % 11;
isbn += last == 10 ? "X" : last.ToString();

Console.WriteLine(isbn);