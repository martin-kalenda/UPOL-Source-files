namespace Database
{
    public class Student : IComparable
    {
        public string OsCislo { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string UserName { get; set; }
        public int Rocnik { get; set; }
        public string OborKomb { get; set; }

        public override string ToString()
        {
            return $"{OsCislo}, {Jmeno}, {Prijmeni}, {UserName}, {Rocnik}, {OborKomb}";
        }
        // CompareTo implementation
        public int CompareTo(object? obj)
        {
            try
            {
                // when comparing to null, consider this object greater
                if (obj == null) return 1;

                Student? otherStudent = obj as Student;

                // check if typecast was successful and compare
                if (otherStudent != null)
                {
                    return Prijmeni.CompareTo(otherStudent.Prijmeni);
                }
                else
                {
                    throw new ArgumentException("Object is not a Student");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
    public class StudentComparer : Comparer<Student>
    {
        // allows to specify by which property to compare
        public string CompareBy { get; set; }
        // constructor with default value
        public StudentComparer(string compareBy = "Prijmeni")
        {
            CompareBy = compareBy;
        }

        // Compare implementation
        public override int Compare(Student? x, Student? y)
        {
            try
            {
                // handle null values of objects
                if (x == null && y == null)
                {
                    return 0;
                }
                else if (x == null)
                {
                    return -1;
                }
                else if (y == null)
                {
                    return 1;
                }

                // get property by name
                var property = typeof(Student).GetProperty(CompareBy);

                // check if property exists
                if (property == null)
                    throw new ArgumentException($"Property {CompareBy} not found");

                // get property values for both objects
                var xValue = property.GetValue(x) as IComparable;
                var yValue = property.GetValue(y) as IComparable;

                // handle null values of properties
                if (xValue == null && yValue == null)
                {
                    return 0;
                }
                else if (xValue == null)
                {
                    return -1;
                }
                else if (yValue == null)
                {
                    return 1;
                }
                return xValue.CompareTo(yValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }

    public class ReadonlyDB
    {
        public static Student[] Students = new Student[]{
            new Student() {OsCislo="R22477", Jmeno="Thomas", Prijmeni="BERGER", UserName="bergth00",Rocnik=2,  OborKomb="INF-OI"},
            new Student() {OsCislo="R22482", Jmeno="My Linh", Prijmeni="DUONGOVÁ", UserName="duonmy00",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22484", Jmeno="Jan", Prijmeni="DVOŘÁK", UserName="dvorja19",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R21390", Jmeno="Martin", Prijmeni="HOLUB", UserName="holuma07",Rocnik=3,  OborKomb="INF-OI"},
            new Student() {OsCislo="R22489", Jmeno="Pavel", Prijmeni="HORÁK", UserName="horapa12",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R23548", Jmeno="Štěpán", Prijmeni="HORÁK", UserName="horast01",Rocnik=1,  OborKomb="INF"},
            new Student() {OsCislo="R23548", Jmeno="Štěpán", Prijmeni="HORÁK", UserName="horast01",Rocnik=1,  OborKomb="INF"},
            new Student() {OsCislo="R22409", Jmeno="Michal", Prijmeni="CHADIM", UserName="chadmi01",Rocnik=2,  OborKomb="IT"},
            new Student() {OsCislo="R21392", Jmeno="Kryštof", Prijmeni="CHADIMA", UserName="chadkr00",Rocnik=3,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22494", Jmeno="Matěj", Prijmeni="CHLEVIŠŤAN", UserName="chlema03",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22495", Jmeno="Jan", Prijmeni="JAROŠ", UserName="jaroja11",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22496", Jmeno="Anita", Prijmeni="JURÁNKOVÁ", UserName="juraan03",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22497", Jmeno="Martin", Prijmeni="KALENDA", UserName="kalema01",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22499", Jmeno="Tomáš", Prijmeni="KOSTKA", UserName="kostto01",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22701", Jmeno="Rostyslav", Prijmeni="LYTVYNENKO", UserName="lytvro00",Rocnik=2, OborKomb="IT"},
            new Student() {OsCislo="R20663", Jmeno="David", Prijmeni="MATÚŠ", UserName="matuda01",Rocnik=4,  OborKomb="IT"},
            new Student() {OsCislo="R23576", Jmeno="Ondřej", Prijmeni="NOVÁK", UserName="novaon06",Rocnik=1,  OborKomb="INF"},
            new Student() {OsCislo="R20671", Jmeno="Michal", Prijmeni="ONDRUŠKA", UserName="ondrmi10", Rocnik=4,  OborKomb="IT"},
            new Student() {OsCislo="R22511", Jmeno="Matouš", Prijmeni="ORSÁG", UserName="orsama01",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22512", Jmeno="Barbora", Prijmeni="PETROVÁ", UserName="petrba09",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R22705", Jmeno="Kateřina", Prijmeni="PLÍVOVÁ", UserName="plivka01",Rocnik=2,  OborKomb="IT"},
            new Student() {OsCislo="R22707", Jmeno="Bohdan", Prijmeni="PROTSENKO", UserName="protbo00",Rocnik=2,  OborKomb="IT"},
            new Student() {OsCislo="R21820", Jmeno="Tereza", Prijmeni="SEDLÁŘOVÁ", UserName="sedlte11", Rocnik=3,  OborKomb="IT"},
            new Student() {OsCislo="R22710", Jmeno="Akim", Prijmeni="SHUSTEROV", UserName="shusak00", Rocnik=2,  OborKomb="IT"},
            new Student() {OsCislo="R22241", Jmeno="Vojtěch", Prijmeni="VYBÍRALÍK", UserName="vybivo00",Rocnik=2,  OborKomb="IVma-Mmi"},
            new Student() {OsCislo="R22532", Jmeno="Zuzana", Prijmeni="ŽEMLIČKOVÁ", UserName="zemlzu00",Rocnik=2,  OborKomb="INF-PVS"},
            new Student() {OsCislo="R21440", Jmeno="Vítek", Prijmeni="ŽVÁČEK", UserName="zvacvi00",Rocnik=3,  OborKomb="INF-PVS"}};
    }
}


