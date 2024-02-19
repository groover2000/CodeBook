using System.Globalization;


Console.WriteLine($"Earliest date/time value is : {DateTime.MinValue}");
Console.WriteLine($"UNIX epoch date/time value is : {DateTime.UnixEpoch}");
Console.WriteLine($"date/time value Now is : {DateTime.Now}");

DateTime christmas = new(2024, 12, 25);

Console.WriteLine(christmas);
Console.WriteLine($"{christmas:dddd, dd MMMM yyyy}");


DateTime beforeXmas = christmas.Subtract(TimeSpan.FromDays(12));
DateTime afterXmas = christmas.Add(TimeSpan.FromDays(12));

Console.WriteLine($"before christmas {beforeXmas}");
Console.WriteLine($"after christmas {afterXmas}");

TimeSpan untilXmas = christmas - DateTime.Now;

Console.WriteLine(untilXmas.Days);


Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture.Name}");

string textDate = "4 july 2024";
DateTime independanceDay = DateTime.Parse(textDate, CultureInfo.GetCultureInfo("ru-Ru"));
Console.WriteLine(independanceDay);