namespace cs208.Models
{
    // Code first Model for the Dogs table
    public class DogModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ShelterId { get; set; }
        public ShelterModel Shelter { get; set; } = null!;
        public string? Breed { get; set; }
        public char Sex { get; set; }
        public byte? Age { get; set; }
        public bool Vaccinated { get; set; }
        public bool Adopted { get; set; }
        public string? Description { get; set; }
    }
}
