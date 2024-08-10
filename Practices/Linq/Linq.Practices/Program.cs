
using Linq.Practices.DbOperations;
using Linq.Practices.Entities;

DataGenerator.Initialize();
LinqDbContext context = new LinqDbContext();
var students = context.Students.ToList<Student>();