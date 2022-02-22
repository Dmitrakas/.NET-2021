using System;

var s = new Stack<int>();
Console.WriteLine(s.IsEmpty());
s.Push(10);
s.Push(20);
Console.WriteLine(s);
Console.WriteLine(s.IsEmpty());
Console.WriteLine("On the Top was " + s.Pop());
Console.WriteLine("On the Top was " + s.Pop());
Console.WriteLine(s);
Console.WriteLine(s.IsEmpty());

var st1 = new Stack<int>();
st1.Push(10);
st1.Push(100);
st1.Push(1000);
//st1 = null;
var st2 = st1.Reverse();
Console.WriteLine(st2);