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
                    ClassId = 1,
                    Name = "Pinar",
                    Surname = "Aliogullari"
                },
                new Student()
                {
                    ClassId = 1,
                    Name = "Emre",
                    Surname = "Kaya"
                },
                new Student()
                {
                    ClassId = 2,
                    Name = "Serkan",
                    Surname = "Aliogullari"
                },
                new Student()
                {
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
