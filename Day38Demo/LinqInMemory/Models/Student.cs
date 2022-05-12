namespace Day38Demo.LinqInMemory.Models;

public class Student
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public double Percentage10Th { get; set; }

    public double Percentage12Th { get; set; }

    public string GetFormattedData()
    {
        return $"{Id} | {FullName} | {Percentage10Th} | {Percentage12Th}";
    }
}
