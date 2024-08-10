
using Linq.Practices.DbOperations;
using Linq.Practices.Entities;

DataGenerator.Initialize();
LinqDbContext context = new LinqDbContext();
var students = context.Students.ToList<Student>();

//Find()
Console.WriteLine("*****Find*****");
var student = context.Students.Where(x => x.Id == 1).FirstOrDefault(); //yerine
student = context.Students.Find(1);
Console.WriteLine(student.Name);


//FirstOrDefault()
Console.WriteLine();
Console.WriteLine("*****FirstOrDefault*****");
student = context.Students.Where(x => x.Surname == "Aliogullari").FirstOrDefault();
Console.WriteLine(student.Name);

//veya
student = context.Students.FirstOrDefault(x => x.Surname == "Aliogullari");
Console.WriteLine(student.Name);


//SingleOrDefault()
Console.WriteLine();
Console.WriteLine("*****SingleOrDefault*****");
student = context.Students.SingleOrDefault(x => x.Name == "Serkan");
/*student = context.Students.SingleOrDefault(x => x.Surname == "Aliogullari"); *///birden fazla veri olduğu için hata fırlatır.
Console.WriteLine(student.Surname);

//ToList()
Console.WriteLine();
Console.WriteLine("*****ToList*****");
var studentList = context.Students.Where(x => x.ClassId == 2).ToList();
Console.WriteLine(studentList.Count);


//OrderBy()
Console.WriteLine();
Console.WriteLine("*****OrderBy*****");
students = context.Students.OrderBy(x => x.Id).ToList();
foreach (var st in students)
{
    Console.WriteLine($"{st.Id} {st.Name} {st.Surname}");
}

//OrderByDescending()
Console.WriteLine();
Console.WriteLine("*****OrderBy*****");
students = context.Students.OrderByDescending(x => x.Id).ToList();
foreach (var st in students)
{
    Console.WriteLine($"{st.Id} {st.Name} {st.Surname}");
}


//Anonymous Object Result
Console.WriteLine();
Console.WriteLine("*****Anonymous Object Result*****");
var anonymousObject = context.Students
                        .Where(x => x.ClassId == 2)
                        .Select(x => new { Id = x.Id, FullName = $"{x.Name} {x.Surname}" });
foreach (var obj in anonymousObject)
{
    Console.WriteLine($"{obj.Id} {obj.FullName}");
}





Console.Read();
