using cs201;
using System.Text.RegularExpressions;

/* * * * * * * * * * * * * * * * * * *
 *                                   *
 *             ÚKOL 2/2              *
 *                                   *
 *              REGEX                *
 *                                   *
 * * * * * * * * * * * * * * * * * * */

string text = "Jméno: Tomáš Davies, Ročník: 2\n" +
              "Jméno: Matěj Dluhoš, Ročník: 2\n" +
              "Jméno: Ondřej Dresler, Ročník: 2\n" +
              "Jméno: Bohumil Federmann, Ročník: 2\n" +
              "Jméno: Petr Gajdošík, Ročník: 2\n" +
              "Jméno: Jakub Galeta, Ročník: 2\n" +
              "Jméno: Michael Hajný, Ročník: 3\n" +
              "Jméno: Thanh Tú Phan, Ročník: 2";

Console.WriteLine($"== REGEX: ==\ntext for regex:\n{text}\n");

//count people
Regex rx1 = new Regex(@"Jméno:");
Console.WriteLine($"number of people: {rx1.Matches(text).Count}");

//get all surnames
Regex rx2 = new Regex(@"(\w+),");
var surnames = rx2.Matches(text).Select(m => m.Groups[1].Value);
Console.WriteLine($"surnames: {String.Join(", ", surnames)}");

//get all grades
Regex rx3 = new Regex(@"Ročník:\s+(\d+)");
var unique_matches = rx3.Matches(text).Select(m => m.Groups[1].Value).Distinct();
Console.WriteLine($"distinct grades: {String.Join(", ", unique_matches)}\n");


/* * * * * * * * * * * * * * * * * * *
 *                                   *
 *             ÚKOL 1/2              *
 *                                   *
 *        PREFIXTREE TESTING         *
 *                                   *
 * * * * * * * * * * * * * * * * * * */

string[] words1 = { "to", "tea", "ted" };
string[] words2 = { "ten", "A", "in", "inn" };
string[] words3 = { "a", "e", "i", "o", "u", "te" };
string[] prefixes = { "t", "", "b", "te", "tea" };

//constructor test
PrefixTree pt1 = new PrefixTree(String.Join(" ", words1));

//Contains() test
Console.WriteLine($"== Testing Contains(): ==\nshould be in tree: {String.Join(", ", words1)}");
foreach (string word in words1)
{
    Console.WriteLine($"tree contains \"{word}\": {pt1.Contains(word)}");
}

Console.WriteLine($"\nshould NOT be in tree: {String.Join(", ", words3)}");
foreach (string word in words3)
{
    Console.WriteLine($"tree contains \"{word}\": {pt1.Contains(word)}");
}

//AddWord() test
Console.WriteLine($"\n== Testing AddWord(): ==\nadding: {String.Join(", ", words2)}");
foreach (string word in words2)
{
    pt1.AddWord(word);
    Console.WriteLine($"tree contains \"{word}\": {pt1.Contains(word)}");
}

//GetChildren() test
Console.WriteLine($"\n== Testing GetChildren(): ==");
foreach (string prefix in prefixes)
{
    Console.WriteLine($"input: \"{prefix}\"");
    Console.Write("children: ");
    pt1.GetChildren(prefix);
    Console.WriteLine();
}

//GetChildrenCount() test
Console.WriteLine($"Testing GetChildren() function:");
foreach (string prefix in prefixes)
{
    Console.WriteLine($"input: \"{prefix}\", children: {pt1.GetChildrenCount(prefix)}");
}

//foreach() test
List<string> texts = new List<string>();

Console.WriteLine($"\nTesting foreach() function:\nprinting all node texts:");
foreach (Node n in pt1)
{
    texts.Add('"' + n.Text + '"');
}
Console.WriteLine(String.Join(", ", texts));


List<string> words = new List<string>();

Console.WriteLine("\nprinting all words:");
foreach (Node n in pt1)
{
    if (n.WordEnd)
    {
        words.Add('"' + n.Text + '"');
    }
}
Console.WriteLine(String.Join(", ", words));