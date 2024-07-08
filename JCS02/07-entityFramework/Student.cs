using System.ComponentModel.DataAnnotations;

namespace cs207
{
    internal class Student
    {
		[Key]
		public string? osCislo { get; set; }
		public string? jmeno { get; set; }
		public string? prijmeni { get; set; }
		public char stav { get; set; }
		public string? userName { get; set; }
		public int stprIdno { get; set; }
		public string? nazevSp { get; set; }
		public string? fakultaSp { get; set; }
		public string? kodSp { get; set; }
		public char formaSp { get; set; }
		public char typSp { get; set; }
		public int typSpKey { get; set; }
		public char mistoVyuky { get; set; }
		public int rocnik { get; set; }
		public string? oborKomb { get; set; }
		public string? oborIdnos { get; set; }
		public char statutPredmetu { get; set; }
		public DateTime casPrihlaseni { get; set; }
		public char znamka { get; set; }
    }
}
