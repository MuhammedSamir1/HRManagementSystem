using HRManagementSystem.Data.Contexts;
using HRManagementSystem.Data.Models.AddressEntity;
using System.Text.Json;

namespace HRManagementSystem.Data.DataSeed
{
    public static class ApplicationDbContextSeeding
    {
        public static bool SeedData(ApplicationDbContext context)
        {
            try
            {
                var hasCountries = context.Country.Any();
                var hasStates = context.State.Any();
                var hasCities = context.City.Any();

                if (hasCountries && hasStates && hasCities) return false;
                if (!hasCountries)
                {
                    var countries = LoadDataFromJsonFile<Country>("countries.json");
                    if (countries.Any()) context.Country.AddRange(countries);
                    context.SaveChanges();
                }

                if (!hasStates)
                {
                    var states = LoadDataFromJsonFile<State>("states.json");
                    if (states.Any()) context.State.AddRange(states);
                    context.SaveChanges();
                }

                if (!hasCities)
                {
                    var cities = LoadDataFromJsonFile<City>("cities.json");
                    if (cities.Any()) context.City.AddRange(cities);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding failed: {ex}");
                return false;
            }
        }


        private static List<T> LoadDataFromJsonFile<T>(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", fileName);
            if (!File.Exists(filePath)) throw new FileNotFoundException();

            string data = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<T>>(data, options) ?? new List<T>();
        }
    }
}
