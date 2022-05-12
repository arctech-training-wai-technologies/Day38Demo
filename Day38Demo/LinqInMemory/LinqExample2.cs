using Day38Demo.LinqInMemory.Models;

namespace Day38Demo.LinqInMemory;

public static class LinqExample2
{
    public static void Test()
    {
        List<Student> students = new()
        {
            new Student { Id = 1, FullName = "Dr. Marianne Kautzer", Percentage10Th = 83, Percentage12Th = 133 },
            new Student { Id = 2, FullName = "Mrs. Ezequiel Lesch", Percentage10Th = 84, Percentage12Th = 486 },
            new Student { Id = 3, FullName = "Miss Pamela Crooks", Percentage10Th = 95, Percentage12Th = 176 },
            new Student { Id = 4, FullName = "Mr. Brielle Cruickshank", Percentage10Th = 89, Percentage12Th = 101 },
            new Student { Id = 5, FullName = "Mrs. Leonor Hilpert", Percentage10Th = 84, Percentage12Th = 118 },
            new Student { Id = 6, FullName = "Dr. Merl Greenfelder", Percentage10Th = 85, Percentage12Th = 534 },
            new Student { Id = 7, FullName = "Dr. Halle DuBuque", Percentage10Th = 87, Percentage12Th = 633 },
            new Student { Id = 8, FullName = "Mrs. Rudolph Bergstrom", Percentage10Th = 86, Percentage12Th = 753 },
            new Student { Id = 9, FullName = "Dr. Sabrina Mayert", Percentage10Th = 87, Percentage12Th = 348 },
            new Student { Id = 10, FullName = "Dr. Gregg Runolfsdottir", Percentage10Th = 97, Percentage12Th = 876 }
        };

        Console.WriteLine("\n** Full Student List");
        foreach (var student in students) { Console.WriteLine(student.GetFormattedData()); }

        LinqDemo(students);

        LinqQueryExpressionDemo(students);

    }

    private static void LinqDemo(List<Student> students)
    {
        // Get all students who scored more than 90%
        var studentsWith90 = students.Where(s => s.Percentage10Th > 90);

        Console.WriteLine("\n** LINQ methods => Student Scoring > 90%");
        foreach (var student in studentsWith90) { Console.WriteLine(student.GetFormattedData()); }

        // Display FullName of all female students who have score more than 84% in 10th
        // SELECT Substr(FullName, xyz) from Student
        // where (Student.FullName like 'Mrs%' or Student.FullName like 'Miss%')
        // and Student.Percentage10Th > 84
        var femaleStudentsWith84 = students.Where(s => 
                                    (s.FullName.Contains("Mrs") || s.FullName.Contains("Miss")) && s.Percentage10Th > 84)
                                    .Select(s => s.FullName);

        Console.WriteLine("\n** LINQ methods => Surname of Female Student Scoring > 84%");
        foreach (var studentName in femaleStudentsWith84) { Console.WriteLine(studentName); }
    }

    private static void LinqQueryExpressionDemo(List<Student> students)
    {
        // Get all students who scored more than 90%
        var studentsWith90 = from s in students
                             where s.Percentage10Th > 90
                             select s;

        Console.WriteLine("\n** LINQ query expression => Student Scoring > 90%");
        foreach (var student in studentsWith90) { Console.WriteLine(student.GetFormattedData()); }

        // Display FullName of all female students who have score more than 84% in 10th
        var femaleStudentsWith84 = from s in students
                                   where (s.FullName.Contains("Mrs") || s.FullName.Contains("Miss")) && s.Percentage10Th > 84
                                   select s.FullName;

        Console.WriteLine("\n** LINQ methods => Surname of Female Student Scoring > 84%");
        foreach (var studentName in femaleStudentsWith84) { Console.WriteLine(studentName); }
    }
}

