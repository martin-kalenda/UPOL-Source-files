using System;

//calculate the discriminant of a quadratic formula
double Discriminant(double a, double b, double c)
{
    double x = b * b - 4 * a * c;
    return x;
}

//print all numbers lower than i and divisible by 7
void DivisibleBySevenFromInterval(int i)
{
    int j = 0;
    while (j < i)
    {
        if (j % 7 == 0 /* && j % 3 != 0*/)
        {
            Console.WriteLine(j);
        }
        j++;
    }
}

//return the n-th number of the Fibonnaci sequence
uint nthFibbonaci(uint n)
{
    if (n <= 1)
    {
        return n;
    }
    else
    {
        return nthFibbonaci(n - 1) + nthFibbonaci(n - 2);
    }
}

//return sum of numbers from 0 until n
uint IntervalSum(uint n)
{
    uint sum = 0;
    for (uint i = 0; i < n; i++)
    {
        sum += i;
    }
    return sum;
}


Console.WriteLine(Discriminant(6, 11, 1));
DivisibleBySevenFromInterval(359);
Console.WriteLine(nthFibbonaci(22));
Console.WriteLine(IntervalSum(55));


