using System.Reflection;

Console.WriteLine("Assembly metadata:");

Assembly? assembly = Assembly.GetEntryAssembly();

if (assembly is null)
{
    Console.WriteLine("Failed to get entry");
    return;
}

Console.WriteLine($"Full name: {assembly.FullName}");
Console.WriteLine($"Location: {assembly.Location}");

IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();

Console.WriteLine("Assembly-level attributes");

foreach (Attribute item in attributes)
{
    Console.WriteLine(item.GetType());
}

AssemblyInformationalVersionAttribute? version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

Console.WriteLine($"version: {version?.InformationalVersion}");

AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

Console.WriteLine($"Company: {company?.Company}");