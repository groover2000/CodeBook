Console.WriteLine("Enter first number between 0 : 255 ");

string? n1 = Console.ReadLine();

Console.WriteLine("Enter second number between 0 : 255 ");

string? n2 = Console.ReadLine();


try
{
    int a = int.Parse(n1);  
    int b = int.Parse(n2);

    int answ = a / b;

    Console.WriteLine($"OMG: {answ}");  
}
catch (FormatException err)
{
    Console.WriteLine($"{err.GetType().Name}");
}