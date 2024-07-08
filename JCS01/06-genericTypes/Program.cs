using _06;

IntSet<string> set1 = new IntSet<string>();
IntSet<string> set2 = new IntSet<string>();

set1.Add("test2");
set1.Add("test3");
set1.Add("test4");

set2.Add("test3");
set2.Add("test4");
set2.Add("test5");

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
set1.Add("test1");
set1.PrintValues();

Console.WriteLine("\nTrying to add duplicate value:");
set1.Add("test1");

// --------------------- 02) ---------------------
Console.WriteLine("\n02) Containts() function:");

Console.WriteLine($"Does set1 contain value \"test1\"?: {set1.Contains("test1")}");
Console.WriteLine($"Does set1 contain value \"test6\"?: {set1.Contains("test6")}");

// --------------------- 03) ---------------------
Console.WriteLine("\n03) Remove() function:");

Console.WriteLine("set1:");
set1.PrintValues();

Console.WriteLine("\nset1 after:");
set1.Remove("test1");
set1.PrintValues();

Console.WriteLine("\nTrying to remove non-existent value:");
set1.Remove("test1");

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

IntSet<string> union = set1.Union(set2);
union.PrintValues();

// --------------------- 06) ---------------------
Console.WriteLine("\n6) Intersection() function:");

IntSet<string> intersect = set1.Intersection(set2);
intersect.PrintValues();

// --------------------- 07) ---------------------
Console.WriteLine("\n7) Subtract() function:");

IntSet<string> subtract = set1.Subtract(set2);
subtract.PrintValues();


// --------------------- 08) ---------------------
IntSet<string> equal = new IntSet<string>();
equal.Add("test4");
equal.Add("test3");

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
IntSet<string> empty = new IntSet<string>();

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

Console.WriteLine($"Is the set empty?: {set1.IsEmpty()}\n");

Console.WriteLine("Foreach test:");

foreach (string s in set1)
{
    Console.Write(s + " ");
}