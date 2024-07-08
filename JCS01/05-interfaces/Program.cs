using _05;

IntPriorityQueue q1 = new IntPriorityQueue();

int val = 0;

Console.WriteLine("is empty? " + q1.IsEmpty());

q1.InsertWithPriority(74, 1);
q1.InsertWithPriority(72, 3);
q1.InsertWithPriority(79, 2);
q1.InsertWithPriority(10, 50);
q1.InsertWithPriority(65, 5);

Console.WriteLine("is empty? " + q1.IsEmpty());

q1.PeekNextValue(out val);
Console.WriteLine("peeking at: " + val);
q1.PopNextValue(out val);
Console.WriteLine("popping: " + val);
q1.PeekNextValue(out val);
Console.WriteLine("peeking at: " + val);
Console.WriteLine("stringify: " + q1.ToString());
