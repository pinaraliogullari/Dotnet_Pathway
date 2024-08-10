using Linq.Practices.Entities;

namespace Linq.Practices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new LinqDbContext())
            {
                if (context.Students.Any())
                    return;
                context.Students.AddRange(
                new Student()
                {
                    Id = 1,
                    ClassId = 1,
                    Name = "Pinar",
                    Surname = "Aliogullari"
                },
                new Student()
                {
                    Id = 2,
                    ClassId = 1,
                    Name = "Emre",
                    Surname = "Kaya"
                },
                new Student()
                {
                    Id = 3,
                    ClassId = 2,
                    Name = "Serkan",
                    Surname = "Aliogullari"
                },
                new Student()
                {
                    Id = 4,
                    ClassId = 2,
                    Name = "Ufuk",
                    Surname = "Aliogullari"
                }
                );
                context.SaveChanges();
            }
        }
    }
}
