//změny stringů náročné operace
//řešení => StringBuilder
/* 
 * StringBuilder sb = new(); - inicializace objektu
 * sb.Append('a');
 * string str = sb.ToString();
 * 
 * taky pozor:
 * string = datový typ
 * String = třída!!
 * 
 * připomenutí: výpis proměnných v řetězci
 * Console.WriteLine($"hodnota promenne: {promenna}");
 */

//01
using System.Dynamic;

uint Fact(uint n)
{
    if (n == 0)
    {
        return 1;
    }
    return n * Fact(n - 1);
}

void PrintFactorial (uint n)
{
    for (uint i = 1; i <= n; i++)
    {
        Console.Write(Fact(i) + ", ");
    }
    Console.WriteLine();
}

//02

//verze 2.0
void PrintSquare2(short n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == 0 || i == n - 1)
            {
                Console.Write('*');
            }
            else if (j == 0 || j == n - 1)
            {
                Console.Write('*');
            }
            else
            {
                Console.Write(' ');
            }
        }
        Console.WriteLine(' ');
    }
}

void PrintCross2(short n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == (n / 2) || j == ( n / 2 ))
            {
                Console.Write('*');
            } else
            {
                Console.Write(' ');
            }
        }
        Console.WriteLine();
    }
}

void Square2 (short n)
{
    if (n % 2 == 0)
    {
        PrintSquare2(n);
    }
    else
    {
        PrintCross2(n);
    }
}


//verze 1.0
void PrintHorizontalLine(short n)
{
    for (int i = 0; i < n; i++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}
void PrintSquare(short n)
{
    PrintHorizontalLine(n);

    for (int i = 0; i < n - 2; i++)
    {
        Console.Write('*');

        for (int j = 0; j < n - 2; j++)
        {
            Console.Write(' ');
        }

        Console.Write('*');
        Console.WriteLine();
    }

    PrintHorizontalLine(n);
}

void PrintVerticalLine(short n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write(' ');
        }
        Console.Write('*');
        Console.WriteLine();
    }
}

void PrintCross(short n)
{
    PrintVerticalLine((short)(n / 2));

    PrintHorizontalLine(n);

    PrintVerticalLine((short)(n / 2));
}
void Square(short n)
{
    if (n % 2 == 0)
    {
        PrintSquare(n);
    } else
    {
        PrintCross(n);
    }
}


//03
uint NumberOfOccurences(string str, char c)
{
    uint count = 0;

    foreach (char ch in str)
    {
        if (ch == c)
        {
            count++;
        }
    }
    return count;
}

//04
string StringTimes(string str, uint n)
{
    string res = str;
    
    while (n > 1)
    {
        if (n != 1)
        {
            res += ", ";
        }

        res += str;
        n--;
    }

    return res;
}

PrintFactorial(5);

Console.WriteLine();

Square2(6);

Console.WriteLine();

Square(6);

Console.WriteLine();

Square2(7);

Console.WriteLine();

Square(7);

Console.WriteLine();

Console.WriteLine(NumberOfOccurences("Retezec", 'e'));

Console.WriteLine();

Console.WriteLine(StringTimes("Retezec", 5));