using _04;

IntSet set1 = new IntSet();
IntSet set2 = new IntSet();

set1.Add(2);
set1.Add(3);
set1.Add(4);

set2.Add(3);
set2.Add(4);
set2.Add(5);

Console.WriteLine("****** INITIAL STATE ******");

Console.WriteLine("\nset1:");
set1.PrintValues();

Console.WriteLine("\nset2:");
set2.PrintValues();

Console.WriteLine("\n***************************");

// --------------------- 01) ---------------------
Console.WriteLine("\n01) Add() function:");

Console.WriteLine("set1:");
set1.PrintValues();

Console.WriteLine("\nset1 after:");
set1.Add(1);
set1.PrintValues();

Console.WriteLine("\nTrying to add duplicate value:");
set1.Add(1);

// --------------------- 02) ---------------------
Console.WriteLine("\n02) Containts() function:");

Console.WriteLine($"Does set1 contain value 1?: {set1.Contains(1)}");
Console.WriteLine($"Does set1 contain value 6?: {set1.Contains(6)}");

// --------------------- 03) ---------------------
Console.WriteLine("\n03) Remove() function:");

Console.WriteLine("set1:");
set1.PrintValues();

Console.WriteLine("\nset1 after:");
set1.Remove(1);
set1.PrintValues();

Console.WriteLine("\nTrying to remove non-existent value:");
set1.Remove(1);

// --------------------- 04) ---------------------
Console.WriteLine("\n4) Size() function:");

Console.WriteLine($"Size of set1: {set1.Size()}");

// -----------------------------------------------
Console.WriteLine("\n****** CURRENT STATE ******");

Console.WriteLine("\nset1:");
set1.PrintValues();

Console.WriteLine("\nset2:");
set2.PrintValues();

Console.WriteLine("\n***************************");

// --------------------- 05) ---------------------
Console.WriteLine("\n5) Union() function:");

IntSet union = set1.Union(set2);
union.PrintValues();

// --------------------- 06) ---------------------
Console.WriteLine("\n6) Intersection() function:");

IntSet intersect = set1.Intersection(set2);
intersect.PrintValues();

// --------------------- 07) ---------------------
Console.WriteLine("\n7) Subtract() function:");

IntSet subtract = set1.Subtract(set2);
subtract.PrintValues();


// --------------------- 08) ---------------------
IntSet equal = new IntSet();
equal.Add(4);
equal.Add(3);

Console.WriteLine("\n8) AreAqual() function:");

Console.WriteLine("Compared sets:");
intersect.PrintValues();
equal.PrintValues();

Console.WriteLine($"Are sets equal?: {intersect.AreAqual(equal)}");

Console.WriteLine("\nCompared sets:");
set1.PrintValues();
set2.PrintValues();

Console.WriteLine($"Are sets equal?: {set1.AreAqual(set2)}");

// --------------------- 09) ---------------------
IntSet empty = new IntSet();

Console.WriteLine("\n9) IsSubsetOf() function:");

Console.WriteLine("Compared sets:");
set1.PrintValues();
set2.PrintValues();

Console.WriteLine($"Is the first set a subset of the other?: {set1.IsSubsetOf(set2)}");

Console.WriteLine("\nCompared sets:");
empty.PrintValues();
set2.PrintValues();

Console.WriteLine($"Is the first set a subset of the other?: {empty.IsSubsetOf(set2)}");

Console.WriteLine("\nCompared sets:");
equal.PrintValues();
set2.PrintValues();

Console.WriteLine($"Is the first set a subset of the other?: {equal.IsSubsetOf(set2)}");

// --------------------- 10) ---------------------
Console.WriteLine("\n10) IsEmpty() function:");

Console.WriteLine("\nChecked set:");
empty.PrintValues();

Console.WriteLine($"Is the set empty?: {empty.IsEmpty()}");

Console.WriteLine("\nChecked set:");
set1.PrintValues();

Console.WriteLine($"Is the set empty?: {set1.IsEmpty()}");