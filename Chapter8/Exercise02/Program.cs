
using System.Text.RegularExpressions;

ConsoleKeyInfo input = Console.ReadKey();

while(ConsoleKey.Escape != input.Key)
{
    Console.WriteLine("Enter RegExp");
    string? pattern = Console.ReadLine();
    Console.WriteLine("Enter a text");
    string? text = Console.ReadLine();
    Console.WriteLine(Regex.IsMatch(text, pattern));

    input = Console.ReadKey();
}
