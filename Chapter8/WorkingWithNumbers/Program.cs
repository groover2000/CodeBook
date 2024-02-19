using System.Numerics;

ulong big = ulong.MaxValue;
Console.WriteLine($"{big,40:N0}");
BigInteger bigInteger = BigInteger.Parse("123456789123456789123456789");
Console.WriteLine($"{bigInteger,40:N0}");
Console.WriteLine(new string('-', 50));

Console.WriteLine("Working with complex numbers");
Complex c1 = new(4, 2);
Complex c2 = new(3, 7);
Complex c3 = c1 + c2;
Console.WriteLine($"{c1} added to {c2} is {c3}");