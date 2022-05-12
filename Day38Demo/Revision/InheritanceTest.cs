namespace Day38Demo.Revision;

public static class InheritanceTest
{
    public static void Test2()
    {
        // Base class/interface variable can refer to a derived class object 
        BaseTest b = new Derived1Test
        {
            Age = 22,
            Marks = 85
        };
    }

	public static void Test()
    {
        BaseTest b = new BaseTest
        {
            Age = 45
        };                  // 4 bytes

        Derived1Test d1 = new Derived1Test
        {
            Age = 22,
            Marks = 85
        };                  // 8 bytes

        Derived2Test d2 = new Derived2Test
        {
            Age = 32,
            Salary = 15000,
            Bonus = 2000
        };					// 24 bytes

        b.Show();           // Age=0
		d1.Show();          // Marks=0 
							// Age=0
		d2.Show();          // Salary=0, Bonus=0
							// Age=0
	}
}

class BaseTest
{
	public int Age { get; set; }    // 4 bytes
	public virtual void Show() { Console.WriteLine($"Age = {Age}"); }
}

class Derived1Test : BaseTest
{
	public int Marks { get; set; }  // 4 bytes

	public override void Show()
	{
		Console.WriteLine($"Marks = {Marks}"); base.Show();
	}
}

class Derived2Test : BaseTest
{
	public double Salary { get; set; }  // 8 bytes
	public double Bonus { get; set; }   // 8 bytes
	public override void Show() { Console.WriteLine($"Salary = {Salary}, Bonus = {Bonus}"); base.Show(); }
}
