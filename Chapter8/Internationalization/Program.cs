using System.Globalization;

CultureInfo globalization = CultureInfo.CurrentCulture;
CultureInfo localization = CultureInfo.CurrentUICulture;

Console.WriteLine($"Current globaliztion name {globalization.Name} {globalization.DisplayName}");
Console.WriteLine($"Current localization name {localization.Name} {localization.DisplayName}");


Console.WriteLine("en-US: English (United States)");
Console.WriteLine("da-DK: Danish (Denmark)");
Console.WriteLine("fr-CA: French (Canada)");

Console.Write("Enter an ISO culture code: ");

string? newCulture = Console.ReadLine();

if (!string.IsNullOrEmpty(newCulture))
{
    CultureInfo ci = new(newCulture);

    CultureInfo.CurrentCulture = ci;
    CultureInfo.CurrentUICulture = ci;

}

Console.Write("Enter your name: ");
string? name = Console.ReadLine();

Console.Write("Enter your date of birth: ");
string? dob = Console.ReadLine();

Console.Write("Enter your salary: ");
string? salary = Console.ReadLine();

DateTime date = DateTime.Parse(dob);
int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
decimal earns = decimal.Parse(salary);

Console.WriteLine(
 "{0} was born on a {1:dddd}, is {2:N0} minutes old, and earns {3:C}",
 name, date, minutes, earns);