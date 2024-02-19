using Packt.Shared;
using static System.Console;

Person bob = new();

WriteLine(new string('-', 20));
WriteLine(bob.ToString());
WriteLine(new string('-', 20));

bob.FavoriteAncientWonder = WondersOfTheAncientWorld.GreatPyramidOfGiza;
bob.BucketList = WondersOfTheAncientWorld.LighthouseOfAlexandria | WondersOfTheAncientWorld.ColossusOfRhodes;
bob.BucketList = (WondersOfTheAncientWorld)18 | (WondersOfTheAncientWorld)1;

bob.Children.Add(new Person() { Name = "Alex" });
bob.Children.Add(new() { Name = "Bob junior" });

WriteLine(new string('-', 20));
WriteLine($"Bob has {bob.Children.Count} childrens:");
WriteLine(new string('-', 20));


foreach (Person children in bob.Children)
{

    WriteLine($"{children.Name}");
    WriteLine(new string('-', 20));
}

BankAccount.InterestRate = 0.12m;

BankAccount johnAccount = new()
{
    AccountName = "John like BIG COCKS",
    Balance = 100000m
};

BankAccount jerryAccount = new()
{
    Balance = 50000m,
    AccountName = "Jerry like BIG COCKS"
};

WriteLine($"NAME: {johnAccount.AccountName} has {johnAccount.Balance * BankAccount.InterestRate}");
WriteLine($"NAME: {jerryAccount.AccountName} has {jerryAccount.Balance * BankAccount.InterestRate}");


Person blankPerson = new();
WriteLine($"NAME: {blankPerson.Name} TIME: {blankPerson.Instantiated}");

Person dickDickson = new("BIGDICK");
WriteLine($"{dickDickson.Name}, TIME: {dickDickson.Instantiated}");

WriteLine(bob.GetOrigin());
bob.WriteToConsole();

bob.Name = "BOB SMITH";
var (Name, Number) = bob.GetFruit();
var (name, dob) = bob;
WriteLine($"{name}, {dob}");


Person sam = new();
sam.Children.Add(new() { Name = "Charlie" });
sam.Children.Add(new() { Name = "Jackson" });
WriteLine($"{bob.Children[0].Name}");

object[] passengers =
{
    new FirstClassPassenger() {AirMiles = 1_419},
    new FirstClassPassenger() {AirMiles = 16_562},
    new BusinessClassPassenger(),
    new CoachClassPassenger() {CarryOnKG = 25.7},
    new CoachClassPassenger() {CarryOnKG = 0},
};

foreach (object passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        FirstClassPassenger p when p.AirMiles > 35000 => 1500m,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750m,
        FirstClassPassenger  => 2000m,
        BusinessClassPassenger => 1000m,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500m,
        CoachClassPassenger => 650m,
        _ => 800m
    };

    WriteLine($"Flight cost {flightCost:C} for {passenger}");
}

ImmutablePerson pers = new()
{
    FirstName = "Jeff",
    LastName = "Peterson"
};

ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};

ImmutableVehicle repaintedCar = car with
{
    Color = "Polymetal Grey Metallic"
};

WriteLine(new string('-', 20));
WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");
WriteLine(new string('-', 20));