using cs205;
using Database;

// print given count of unique fullnames of students from array starting at start, if count is negative prints until the end of the array
void printUnique(Student[] students, int start, int count)
{
    try
    {
        // check if start is in bounds
        if (start < 0 || start >= students.Length)
        {
            throw new IndexOutOfRangeException();
        }

        List<string> uniqueFullnames = new List<string>();
        string fullname = "";

        while (true)
        {
            // if there are no more students or count is 0, break the loop
            if (count == 0 || start >= students.Length)
                break;

            fullname = $"{students[start].Jmeno} {students[start].Prijmeni}";

            // check if name is unique, if yes add it to the list
            if (!uniqueFullnames.Contains(fullname))
            {
                uniqueFullnames.Add(fullname);
                count--;
            }
            start++;
        }
        Console.WriteLine(string.Join(", ", uniqueFullnames));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw;
    }
}


//////////
//
//  01
//

// copy and shuffle the Student array
Random rng = new Random();
Student[] copy = ReadonlyDB.Students;
rng.Shuffle(copy);
Student[] copyLinq = (Student[])copy.Clone();

// sort array using MergeSort
Sort.MergeSort(copy);

// print unique full names of students from 3rd to 8th position
Console.WriteLine("Six unique full names from 3rd to 8th position\nwithout LINQ:");
printUnique(copy, 2, 6);


//////////
//
//  02
//

// do all of the above using LINQ
string[] sixUniqueNamesAndSurnames = copyLinq.OrderBy(s => s.Prijmeni)
                                             .Select(s => $"{s.Jmeno} {s.Prijmeni}")
                                             .Distinct()
                                             .Skip(2)
                                             .Take(6)
                                             .ToArray();
Console.WriteLine("\nwith LINQ:");
Console.WriteLine(String.Join(", ", sixUniqueNamesAndSurnames));


//////////
//
//  03
//

//return first fifth year or higher student
object? firstFifthYearOrHigher = copyLinq.FirstOrDefault(s => s.Rocnik >= 5);
Console.WriteLine($"\nFirst fifth year student: {firstFifthYearOrHigher ?? "null"}");


//////////
//
//  04
//

// return all students from INF-PVS
int infPvsCount = copyLinq.Count(s => s.OborKomb == "INF-PVS");
Console.WriteLine($"\nStudents of INF-PVS: {infPvsCount}");


//////////
//
//  05
//

//check if any student is named Lukáš
bool lukasExists = copyLinq.Any(s => s.Jmeno == "Lukáš");
Console.WriteLine($"\nLukáš exists: {lukasExists}");