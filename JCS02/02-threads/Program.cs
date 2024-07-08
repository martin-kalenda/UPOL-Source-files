using cs202;
using System.Diagnostics;

//maximum depth of parallelism used for testing
const int MaxTestDepth = 3;
//size of array used for testing
const int ArraySize = 100000000;

int[] numbers = new int[ArraySize];
FillArray(numbers);

//measure time for sequential MergeSort
Stopwatch sw = Stopwatch.StartNew();
Sort.MergeSort((int[])numbers.Clone());
sw.Stop();
Console.WriteLine($"Sequential MergeSort: {sw.ElapsedMilliseconds}ms");

//measure time for parallel MergeSort
for (int i = 1; i <= MaxTestDepth; i++)
{
    sw.Restart();
    Sort.MergeSort((int[])numbers.Clone(), i);
    sw.Stop();
    Console.WriteLine($"\nParallel MergeSort, depth = {i}: {sw.ElapsedMilliseconds}ms");
    Console.WriteLine($"Threads initialized: ~{Sort.ThreadsCounter}");
}

//fill array with random numbers
void FillArray(int[] array)
{
    Random random = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(0, Int32.MaxValue);
    }
}
