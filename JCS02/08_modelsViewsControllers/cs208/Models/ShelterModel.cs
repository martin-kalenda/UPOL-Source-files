using Microsoft.EntityFrameworkCore;

namespace cs208.Models
{
    // Code first Model for the Shelters table
    public class ShelterModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string HouseNo { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<DogModel> Dogs { get; } = new List<DogModel>();
    }
}
