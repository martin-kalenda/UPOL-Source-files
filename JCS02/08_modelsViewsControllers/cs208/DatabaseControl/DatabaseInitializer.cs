using cs208.Models;
using System.Data.Common;

namespace cs208.DatabaseControl
{
    // Class for initializing the database and filling it with data
    public class DatabaseInitializer
    {
        // Recreate the database
        public static void Initialize()
        {
            try
            {
                using (Context dbc = new Context())
                {
                    if (dbc.Database.EnsureDeleted())
                        Console.WriteLine("DatabaseInitializer: database deleted");

                    if (dbc.Database.EnsureCreated())
                        Console.WriteLine("DatabaseInitializer: database created");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseInitializer: Error when initializing - " + ex.Message);
            }
        }
        // Fill database with initial data
        public static void AddEntries()
        {
            try
            {
                // add shelters
                using (Context dbc = new Context())
                {
                    var shelters = new ShelterModel[]
                    {
                        new ShelterModel { Name = "Paws and Claws Shelter",            Street = "Main Street",  HouseNo = "123", ZipCode = "10001", City = "New York",    Country = "USA", Phone = "123-456-7890", Email = "info@pawsandclaws.com",       Description = "A shelter dedicated to finding loving homes for pets in need." },
                        new ShelterModel { Name = "Happy Tails Animal Rescue",         Street = "Oak Avenue",   HouseNo = "456", ZipCode = "90002", City = "Los Angeles", Country = "USA", Phone = "987-654-3210", Email = "happytailsrescue@email.com",  Description = "Committed to rescuing and rehabilitating animals to give them a second chance at happiness." },
                        new ShelterModel { Name = "Furry Friends Haven",               Street = "Maple Street", HouseNo = "789", ZipCode = "60601", City = "Chicago",     Country = "USA", Phone = "555-123-4567", Email = "info@furryfriendshaven.org",  Description = null},
                        new ShelterModel { Name = "Whiskers and Wags Adoption Center", Street = "Cedar Lane",   HouseNo = "246", ZipCode = "20001", City = "Washington",  Country = "USA", Phone = "321-789-4561", Email = "whiskersandwags@gmail.com",   Description = "Dedicated to finding loving homes for cats and dogs through adoption and community education." },
                        new ShelterModel { Name = "Hopeful Hearts Animal Sanctuary",   Street = "Elm Street",   HouseNo = "135", ZipCode = "30303", City = "Atlanta",     Country = "USA", Phone = "678-901-2345", Email = "hopefulhearts@sanctuary.org", Description = "Rescuing and providing lifelong care for animals with special needs, ensuring they receive the love and attention they deserve." }
                    };


                    dbc.Shelters.AddRange(shelters);
                    dbc.SaveChanges();
                    Console.WriteLine("DatabaseInitializer: shelters added");
                }

                // add dogs
                using (Context dbc = new Context())
                {
                    var dogs = new DogModel[]
                    {
                        new DogModel { Name = "Max",     ShelterId = 1, Breed = "Labrador Retriever",            Sex = 'M', Age = 3, Vaccinated = true, Description = "Friendly and energetic, loves to play fetch." },
                        new DogModel { Name = "Bella",   ShelterId = 2, Breed = "Golden Retriever",              Sex = 'F', Age = 2, Vaccinated = true, Description = "Gentle and affectionate, enjoys cuddling." },
                        new DogModel { Name = "Charlie", ShelterId = 3, Breed = "German Shepherd",               Sex = 'M', Age = 4, Vaccinated = true, Description = "Intelligent and loyal, enjoys long walks." },
                        new DogModel { Name = "Lucy",    ShelterId = 4, Breed = "Beagle",                        Sex = 'F', Age = 1, Vaccinated = false, Description = "Playful and curious, loves to explore." },
                        new DogModel { Name = "Cooper",  ShelterId = 5, Breed = "Siberian Husky",                Sex = 'M', Age = 2, Vaccinated = true, Description = "Energetic and adventurous, enjoys outdoor activities." },
                        new DogModel { Name = "Daisy",   ShelterId = 1, Breed = "Boxer",                         Sex = 'F', Age = 3, Vaccinated = true, Description = "Playful and affectionate, loves to chase squirrels." },
                        new DogModel { Name = "Rocky",   ShelterId = 2, Breed = "Bulldog",                       Sex = 'M', Age = 2, Vaccinated = true, Description = "Strong and loyal, enjoys lounging around." },
                        new DogModel { Name = "Luna",    ShelterId = 3, Breed = "Poodle",                        Sex = 'F', Age = 4, Vaccinated = true, Description = "Gentle and intelligent, enjoys learning new tricks." },
                        new DogModel { Name = "Milo",    ShelterId = 4, Breed = "Dachshund",                     Sex = 'M', Age = 2, Vaccinated = true, Description = "Curious and playful, loves to dig." },
                        new DogModel { Name = "Zoe",     ShelterId = 5, Breed = "Shih Tzu",                      Sex = 'F', Age = 3, Vaccinated = true, Description = "Sweet and affectionate, loves belly rubs." },
                        new DogModel { Name = "Bailey",  ShelterId = 1, Breed = "Australian Shepherd",           Sex = 'M', Age = 1, Vaccinated = true, Description = "Smart and energetic, enjoys agility training." },
                        new DogModel { Name = "Sadie",   ShelterId = 2, Breed = "Boxer",                         Sex = 'F', Age = 5, Vaccinated = true, Description = "Loyal and protective, loves her family." },
                        new DogModel { Name = "Tucker",  ShelterId = 3, Breed = "Golden Retriever",              Sex = 'M', Age = 2, Vaccinated = true, Description = "Friendly and outgoing, loves making new friends." },
                        new DogModel { Name = "Maggie",  ShelterId = 4, Breed = "Labrador Retriever",            Sex = 'F', Age = 3, Vaccinated = true, Description = "Sweet-natured and loyal, loves water." },
                        new DogModel { Name = "Jackson", ShelterId = 5, Breed = "Husky",                         Sex = 'M', Age = 4, Vaccinated = true, Description = "Independent and playful, needs space to roam." },
                        new DogModel { Name = "Chloe",   ShelterId = 1, Breed = "Cavalier King Charles Spaniel", Sex = 'F', Age = 2, Vaccinated = true, Description = "Gentle and affectionate, great with kids." },
                        new DogModel { Name = "Bear",    ShelterId = 2, Breed = "Bernese Mountain Dog",          Sex = 'M', Age = 3, Vaccinated = true, Description = "Gentle giant, loves to cuddle." },
                        new DogModel { Name = "Lola",    ShelterId = 3, Breed = "French Bulldog",                Sex = 'F', Age = 1, Vaccinated = true, Description = "Sassy and playful, enjoys lounging in the sun." },
                        new DogModel { Name = "Oliver",  ShelterId = 4, Breed = "Pug",                           Sex = 'M', Age = 2, Vaccinated = true, Description = "Charming and mischievous, loves attention." },
                        new DogModel { Name = "Ruby",    ShelterId = 5, Breed = "Border Collie",                 Sex = 'F', Age = 4, Vaccinated = true, Description = "Highly intelligent and active, needs mental stimulation." },
                        new DogModel { Name = "Buddy",   ShelterId = 1, Breed = "Shiba Inu",                     Sex = 'M', Age = 3, Vaccinated = true, Description = "Independent and loyal, enjoys exploring outdoors." },
                        new DogModel { Name = "Molly",   ShelterId = 2, Breed = "Cocker Spaniel",                Sex = 'F', Age = 2, Vaccinated = true, Description = "Sweet and gentle, loves cuddling on the couch." },
                        new DogModel { Name = "Zeus",    ShelterId = 3, Breed = "Rottweiler",                    Sex = 'M', Age = 4, Vaccinated = true, Description = "Strong and protective, needs experienced owner." },
                        new DogModel { Name = "Sasha",   ShelterId = 4, Breed = "Great Dane",                    Sex = 'F', Age = 3, Vaccinated = true, Description = "Gentle giant, loves being around people." },
                        new DogModel { Name = "Rosie",   ShelterId = 5, Breed = "Dalmatian",                     Sex = 'F', Age = 2, Vaccinated = true, Description = "Energetic and loyal, enjoys long runs." },
                        new DogModel { Name = "Oscar",   ShelterId = 1, Breed = "Jack Russell Terrier",          Sex = 'M', Age = 5, Vaccinated = true, Description = "Energetic and intelligent, needs mental and physical exercise." },
                        new DogModel { Name = "Harley",  ShelterId = 2, Breed = "Doberman Pinscher",             Sex = 'M', Age = 2, Vaccinated = true, Description = "Fearless and loyal, needs consistent training." },
                        new DogModel { Name = "Penny",   ShelterId = 3, Breed = "Basset Hound",                  Sex = 'F', Age = 3, Vaccinated = true, Description = "Gentle and affectionate, loves to howl." },
                        new DogModel { Name = "Teddy",   ShelterId = 4, Breed = "Shetland Sheepdog",             Sex = 'M', Age = 4, Vaccinated = true, Description = "Intelligent and affectionate, loves herding." },
                        new DogModel { Name = "Loki",    ShelterId = 5, Breed = "Alaskan Malamute",              Sex = 'M', Age = 3, Vaccinated = true, Description = "Strong-willed and independent, needs firm leadership." }
                    };

                    dbc.Dogs.AddRange(dogs);
                    dbc.SaveChanges();
                    Console.WriteLine("DatabaseInitializer: dogs added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DatabaseInitializer: Error when addind entries - " + ex.Message);
            }
        }
    }
}