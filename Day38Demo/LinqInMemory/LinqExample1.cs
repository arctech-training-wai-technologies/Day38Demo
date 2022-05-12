namespace Day38Demo.LinqInMemory;

public static class LinqExample1
{
    public static void Test()
    {
        var xyz = EvenNumbersWithoutLinq();

        Console.WriteLine("\nEven numbers without LINQ");
        foreach (var item in xyz) { Console.Write($"{item},"); }

        var enumerableNumbers = EvenNumbersWithLinq();

        Console.WriteLine("\nEven numbers with LINQ");
        foreach (var item in enumerableNumbers) { Console.Write($"{item},"); }

        var enumerableNumbers2 = EvenNumbersWithLinqQueryExpression();

        Console.WriteLine("\nEven numbers with LINQ Query expressions");
        foreach (var item in enumerableNumbers) { Console.Write($"{item},"); }
    }

    private static IEnumerable<int> EvenNumbersWithLinqQueryExpression()
    {
        int[] arr = { 1, 2, 3, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("\nOriginal List of numbers");
        foreach (var item in arr) { Console.Write($"{item},"); }

        var list = from item in arr
                   where item %2 == 0
                   select item;

        return list;

    }

    private static IEnumerable<int> EvenNumbersWithLinq()
    {
        int[] arr = { 1, 2, 3, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("\nOriginal List of numbers");
        foreach (var item in arr) { Console.Write($"{item},"); }

        var list = arr.Where(item => item % 2 == 0);

        return list;
    }

    private static IEnumerable<int> EvenNumbersWithoutLinq()
    {
        int[] arr = { 1, 2, 3, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Original List of numbers");
        foreach (var item in arr) { Console.Write($"{item},"); }

        var list = new List<int>();

        foreach (var item in arr)
        {
            if(item % 2 == 0)
                list.Add(item);
        }

        return list;
    }
}
