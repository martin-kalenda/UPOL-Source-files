using System.Xml;
using cs207;

// Refresh the database by deleting and creating a new one
void refreshDatabase()
{
    try
    {
        using (StudentsContext dbContext = new StudentsContext())
        {
            if (dbContext.Database.EnsureDeleted())
                Console.WriteLine("Database deleted");

            if (dbContext.Database.EnsureCreated())
                Console.WriteLine("Database created");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occured while refreshing the database: " + ex.Message);
    }
}

// Serialize the XML file and return a list of nodes
XmlNodeList? serializeXml(string path)
{
    try
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        if (doc.DocumentElement == null)
        {
            return null;
        }
        return doc.DocumentElement.ChildNodes;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occured while serializing the XML file: " + ex.Message);
        return null;
    }
}

// Add XML node entries to database
void addDatabaseEntries(XmlNodeList data)
{
    try
    {
        using (StudentsContext dbContext = new StudentsContext())
        {
            Random randomGrade = new Random();
            foreach (XmlNode node in data)
            {
                dbContext.Add(new Student
                {
                    osCislo        = node["osCislo"]?.InnerText,
                    jmeno          = node["jmeno"]?.InnerText,
                    prijmeni       = node["prijmeni"]?.InnerText,
                    stav           = char.Parse(node["stav"].InnerText),
                    userName       = node["userName"]?.InnerText,
                    stprIdno       = int.Parse(node["stprIdno"].InnerText),
                    nazevSp        = node["nazevSp"]?.InnerText,
                    fakultaSp      = node["fakultaSp"]?.InnerText,
                    kodSp          = node["kodSp"]?.InnerText,
                    formaSp        = char.Parse(node["formaSp"].InnerText),
                    typSp          = char.Parse(node["typSp"].InnerText),
                    typSpKey       = int.Parse(node["typSpKey"].InnerText),
                    mistoVyuky     = char.Parse(node["mistoVyuky"].InnerText),
                    rocnik         = int.Parse(node["rocnik"].InnerText),
                    oborKomb       = node["oborKomb"].InnerText,
                    oborIdnos      = node["oborIdnos"].InnerText,
                    statutPredmetu = char.Parse(node["statutPredmetu"].InnerText),
                    casPrihlaseni  = DateTime.Parse(node["casPrihlaseni"].InnerText),
                    znamka         = (char)randomGrade.Next('A', 'F' + 1)
                });
            }
            dbContext.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occured while adding entries to the database: " + ex.Message);
    }
}

// XML source file path
string path = @"C:\Users\Marti\Desktop\studentiPredmetu.xml";

refreshDatabase();
XmlNodeList? serializedObjects = serializeXml(path);

if (serializedObjects != null)
{
    addDatabaseEntries(serializedObjects);
}

// print unique full names of students from 3rd to 8th position
using (StudentsContext dbContext = new StudentsContext())
{
    string[] sixUniqueNamesAndSurnames = dbContext.Students.OrderBy(s => s.prijmeni)
                                                 .Select(s => $"{s.jmeno} {s.prijmeni}")
                                                 .Distinct()
                                                 .Skip(2)
                                                 .Take(6)
                                                 .ToArray();

    Console.WriteLine("\nSix unique names and surnames:");
    Console.WriteLine(String.Join(", ", sixUniqueNamesAndSurnames));
}

// add two new students
using (StudentsContext dbContext = new StudentsContext())
{
    dbContext.Add(new Student
    {
        osCislo = "R18264",
        jmeno = "John",
        prijmeni = "DOE",
        stav = 'S',
        userName = "doejo01",
        stprIdno = 1234,
        nazevSp = "Informatika pro vzdělávání",
        fakultaSp = "PRF",
        kodSp = "B0114A140001",
        formaSp = 'P',
        typSp = 'B',
        typSpKey = 7,
        mistoVyuky = 'O',
        rocnik = 1,
        oborKomb = "IVma-Mmi",
        oborIdnos = "5427,5434",
        statutPredmetu = 'B',
        casPrihlaseni = DateTime.Now,
        znamka = 'A'
    });

    dbContext.Add(new Student
    {
        osCislo = "R18265",
        jmeno = "Jane",
        prijmeni = "DOE",
        stav = 'S',
        userName = "doeja10",
        stprIdno = 1236,
        nazevSp = "Informatika",
        fakultaSp = "PRF",
        kodSp = "B0613A140019",
        formaSp = 'P',
        typSp = 'B',
        typSpKey = 7,
        mistoVyuky = 'O',
        rocnik = 2,
        oborKomb = "INF-PVS",
        oborIdnos = "6721",
        statutPredmetu = 'B',
        casPrihlaseni = DateTime.Now,
        znamka = 'B'
    });
    dbContext.SaveChanges();
    Console.WriteLine("\nTwo new students added");
}

// delete IT students
using (StudentsContext dbContext = new StudentsContext())
{
    var itStudents = dbContext.Students.Where(s => s.oborKomb == "IT").ToArray();
    dbContext.RemoveRange(itStudents);
    dbContext.SaveChanges();
    Console.WriteLine("\nIT students deleted");
}

// update username of student with osCislo "R21390"
using (StudentsContext dbContext = new StudentsContext())
{
    var student = dbContext.Students.Where(s => s.osCislo == "R21390").FirstOrDefault();
    if (student != null)
    {
        student.userName = "holuma08";
        dbContext.SaveChanges();
        Console.WriteLine("\nUsername of student with osCislo \"R21390\" updated");
    }
}

// print remaining students and their grades
using (StudentsContext dbContext = new StudentsContext())
{
    var students = dbContext.Students.ToArray();

    Console.WriteLine("\nRemaining students and their grades:");
    foreach (var student in students)
    {
        Console.WriteLine($"{student.osCislo}, {student.jmeno} {student.prijmeni} - {student.znamka}");
    }
}