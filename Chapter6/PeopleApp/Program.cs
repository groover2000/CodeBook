using Packt.Shared;

Person harry = new() { Name = "Harry" };
Person mary = new() { Name = "Marry" };
Person jill = new() { Name = "Jill" };

Person baby1 = harry.ProcreateWith(mary);
baby1.Name = "Gary";

Person baby2 = Person.Procreate(harry, jill);
Person baby3 = harry * mary;

Console.WriteLine($"{harry.Name} has a {harry.Children.Count} childrens");
Console.WriteLine($"{mary.Name} has a {mary.Children.Count} childrens");
Console.WriteLine($"{jill.Name} has a {jill.Children.Count} childrens");
Console.WriteLine($"First {harry.Name} child name {harry.Children[0].Name}");

static void Harry_Shout(object? sender, EventArgs e)
{
    if (sender is null) return;
    Person p = (Person)sender;
    Console.WriteLine($"{p.Name} is this angry {p.AngerLevel}");
};

harry.Shout += Harry_Shout;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();


System.Collections.Hashtable lookupObject = new();
lookupObject.Add(1, "Alpha");
lookupObject.Add(2, "Beta");
lookupObject.Add(3, "Gamma");
lookupObject.Add(harry, "   Delta");

Dictionary<int, string> lookupInString = new();
lookupInString.Add(1, "First");
lookupInString.Add(2, "Second");
lookupInString.Add(3, "Third");
lookupInString.Add(4, "Fourth");


Person[] people =
{
    new() {Name = "Simon"},
    new() {Name = "Adam"},
    new() {Name = "Gretam"},
    new() {Name = "Betam"},
};

Array.Sort(people, new PersonComparer());
foreach(Person human in people)
{
    Console.WriteLine($"{human.Name}");
}

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);

DisplacementVector dv3 = dv1 + dv2;

Console.WriteLine(dv3.X);

