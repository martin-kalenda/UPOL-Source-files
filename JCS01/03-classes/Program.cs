IntMatrix a = new IntMatrix(2, 2);

Console.WriteLine(a.NRows());
Console.WriteLine(a.NCols());
Console.WriteLine(a.GetVal(0, 1));

a.SetVal(0, 1, 20);
Console.WriteLine(a.GetVal(0, 1));

Console.WriteLine(a.NonZero());
Console.WriteLine(a.SumOfVals());

IntMatrix b = IntMatrix.Ones(2, 2);

IntMatrix d = a.MulMatrix(b);
d.Print();

IntMatrix c = a.AddMatrix(b);
c.Print();


