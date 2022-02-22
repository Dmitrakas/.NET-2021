using System;

var practice1 = new Practice { Task = "T1", Solution = "S1" };
var practice2 = new Practice { Task = "T2", Solution = "S2" };

var training = new Training();
training.Add(practice1);
training.Add(practice2);

Console.WriteLine(training.IsPractical());

training.Add(new Lecture { Topic = "Topic1" });

Console.WriteLine(training.IsPractical());