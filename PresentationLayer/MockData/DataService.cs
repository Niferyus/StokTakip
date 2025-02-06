using PresentationLayer.Models;

namespace PresentationLayer.MockData
{
    public static class DataService
    {
        public static List<City> GetIller()
        {
            return new List<City>
        {
            new City { Id = 1, Name = "İstanbul" },
            new City { Id = 2, Name = "Ankara" },
            new City { Id = 3, Name = "İzmir" }
        };
        }

        public static List<District> GetIlceler()
        {
            return new List<District>
        {
            new District { Id = 1, Name = "Kadıköy", CityId = 1 },
            new District { Id = 2, Name = "Beşiktaş", CityId = 1 },
            new District { Id = 3, Name = "Çankaya", CityId = 2 },
            new District { Id = 4, Name = "Keçiören", CityId = 2 },
            new District { Id = 5, Name = "Konak", CityId = 3 }
        };
        }
    }
}
