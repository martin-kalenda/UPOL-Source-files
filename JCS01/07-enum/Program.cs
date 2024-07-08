using _07;

//UpperAfterSpace()
string s = "nejaka dlouha veta, kde budu zvetsovat pismena";

Console.WriteLine(s.UpperAfterSpace() + "\n");

//enum ChessPiece and GetBoard();
ChessPiece[,] board = Chess.GetBoard();

board.Print();
Console.WriteLine();

//WhenTimesFactor()
DateTime son = new DateTime(2019, 1, 1);
DateTime father = new DateTime(1992, 1, 1);
int factor = 3;

DateTime result = StaticMethods.WhenTimesFactor(son, father, factor);

if (result.CompareTo(DateTime.Now) < 0)
{
    Console.WriteLine($"Otec byl presne {factor}x starsi nez syn v datu: {result}");
} else
{
    Console.WriteLine($"Otec bude presne {factor}x starsi nez syn v datu: {result}");
}

//Queue exceptions
IntPriorityQueue q = new IntPriorityQueue();
int val = 0;

//q.PopNextValue(out val);

q.InsertWithPriority(1, 1);
q.InsertWithPriority(1, 2);
q.InsertWithPriority(1, 3);
q.InsertWithPriority(1, 6);
q.InsertWithPriority(1, 3);