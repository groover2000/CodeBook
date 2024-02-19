
string city = "London";
Console.WriteLine($"{city} is {city.Length} characters long");
Console.WriteLine($"First char is {city[0]} and third char is {city[2]}");

string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellín";
string[] citiesArray = cities.Split(',');

Console.WriteLine($"There are {citiesArray.Length} items in the array");


foreach (string item in citiesArray)
{
    Console.WriteLine(item);
}

string fullName = "Alan Jones";
int? indexOfTheSpace = fullName.IndexOf(' ');

string firstName = fullName.Substring(0, (int)indexOfTheSpace);

string lastName = fullName.Substring((int)indexOfTheSpace + 1);

Console.WriteLine($"Original: {fullName}");
Console.WriteLine($"Swapped: {lastName}, {firstName}");

string company = "Microsoft";
bool startsWithM = company.StartsWith('M');
bool containsN = company.Contains('N');
Console.WriteLine($"Text {company}");
Console.WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}");

string recombine = string.Join("=>", citiesArray);
Console.WriteLine(recombine);