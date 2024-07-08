using System.Text.RegularExpressions;

namespace _07
{
    public static class StaticMethods
    {
        //Make the first letter of each word in a string uppercase
        public static string UpperAfterSpace(this string input)
        {
            string pattern = @"\b\p{Ll}";

            return Regex.Replace(input, pattern, match => match.Value.ToUpper());
        }
        //Calculate when father will be factor times older than his son based on their birthdates
        public static DateTime WhenTimesFactor(DateTime son, DateTime father, int factor)
        {
            if (son.CompareTo(father) < 1)
            {
                throw new ArgumentException("Father must be older than his son.");
            }

            if (factor < 2)
            {
                throw new ArgumentException("Invalid factor, must be higher than 1.");
            }

            long sonAge = DateTime.Now.Ticks - son.Ticks;
            long fatherAge = DateTime.Now.Ticks - father.Ticks;

            DateTime result = new DateTime(DateTime.Now.Ticks + (factor * sonAge - fatherAge) / (1 - factor));

            return result;
        }
        //Print chessboard
        public static void Print(this ChessPiece[,] board)
        {
            ConsoleColor backgroundBackup = Console.BackgroundColor;
            ConsoleColor foregroundBackup = Console.ForegroundColor;

            for (int i = 7; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = backgroundBackup;
                    Console.BackgroundColor = foregroundBackup;
                }
                else
                {
                    Console.ForegroundColor = foregroundBackup;
                    Console.BackgroundColor = backgroundBackup;
                }
                for (int j = 0; j < 8; j++)
                {
                    if (Console.ForegroundColor == backgroundBackup)
                    {
                        Console.ForegroundColor = foregroundBackup;
                        Console.BackgroundColor = backgroundBackup;
                    }
                    else
                    {
                        Console.ForegroundColor = backgroundBackup;
                        Console.BackgroundColor = foregroundBackup;
                    }
                    Console.Write($" {board[i, j].ToString().PadLeft(11)} ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = backgroundBackup;
            Console.ForegroundColor = foregroundBackup;
        }
    }
}
