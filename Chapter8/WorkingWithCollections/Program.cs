using System.Collections.Immutable;

static void Output(string title, IEnumerable<string> collection)
{
    Console.WriteLine(title);
    foreach (string item in collection)
    {
        Console.WriteLine(item);
    }

}

static void WorkingWithLists()
{
    // List<string> cities = new();
    // cities.Add("London");
    // cities.Add("Paris");
    // cities.Add("Milan");

    // List<string> cities = new() { "London", "Paris, Milan" };

    // List<string> cities = ["London", "Paris", "Milan"];
    List<string> cities = new();
    cities.AddRange(new[] { "London", "Paris", "Milan" });

    Output("Initial List", cities);

    Console.WriteLine($"The first city is {cities[0]}");
    Console.WriteLine($"The last city is {cities[^1]}");


    cities.Insert(0, "Sydney");

    Output("After inserting Sydney at index 0", cities);
    cities.RemoveAt(1);
    cities.Remove("Milan");

    Output("After removing 2 cities", cities);

    ImmutableList<string> immutableCities = cities.ToImmutableList();
    ImmutableList<string> newList = immutableCities.Add("Rio");

    Output("Immutable list of cities:", immutableCities);
    Output("New list of cities:", newList);
}


static void WorkingWithDictionaries()
{
    Console.WriteLine(new string('-', 20));
    Dictionary<string, string> keywords = [];

    // Dictionary<string, string> keywords = new ()
    // {
    //     {"int", "32"},
    //     {"long", "64"}
    // }

    keywords.Add(key: "int", value: "32-bit integer data-type");
    keywords.Add("long", "64-bit integer data-type");
    keywords.Add("float", "Single precision floating point number");

    Output("Dictionary keys:", keywords.Keys);
    Output("Dictionary values:", keywords.Values);

    Console.WriteLine("Keywords and their definitions");
    foreach (KeyValuePair<string, string> item in keywords)
    {
        Console.WriteLine($"{item.Key} : {item.Value}");
    }

    string key = "long";
    Console.WriteLine($"The definition of {key} is {keywords[key]}");

}

static void WorkingWithQueues()
{
    Queue<string> coffee = [];
    coffee.Enqueue("Damir");
    coffee.Enqueue("Andrea");
    coffee.Enqueue("Ronald");
    coffee.Enqueue("Amin");
    coffee.Enqueue("Irina");

    Output("Initial queue from front to back", coffee);

    string served = coffee.Dequeue();
    Console.WriteLine($"Served: {served}");

    served = coffee.Dequeue();
    Console.WriteLine($"Served: {served}");

    Output("Current queue from front to back", coffee);
    Console.WriteLine($"{coffee.Peek()} is next line");
}

static void OutputPQ<TElement, TPriority>(string title, IEnumerable<(TElement Element, TPriority Priority)> collection)
{
    Console.WriteLine(title);
    foreach ((TElement, TPriority) item in collection)
    {
        Console.WriteLine($"{item.Item1} {item.Item2}");
    }
}

static void WorkingWithPriorityQueues()
{
    PriorityQueue<string, int> vaccine = new();
    vaccine.Enqueue("Pamela", 1);
    vaccine.Enqueue("Rebecca", 3);
    vaccine.Enqueue("Juliet", 2);
    vaccine.Enqueue("Ian", 1);

    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);
    Console.WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

    vaccine.Enqueue("Mark", 2);
    Console.WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");
    OutputPQ("Current queue for vaccination:", vaccine.UnorderedItems);

}

WorkingWithLists();
// WorkingWithDictionaries();
// WorkingWithQueues();
// WorkingWithPriorityQueues();
