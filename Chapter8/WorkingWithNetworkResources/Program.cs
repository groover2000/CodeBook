using System.Net; //  IPHostEntry, Dns, IPAddress
using System.Net.NetworkInformation; // Ping, PingReply, IPStaus

Console.WriteLine("Enter a valid web address:");

string? url = Console.ReadLine();

if (string.IsNullOrWhiteSpace(url))
{
    url = "https://stackoverflow.com/search?q=securestring";
}

Uri uri = new(url);

Console.WriteLine($"URL {url}");
Console.WriteLine($"Scheme {uri.Scheme}");
Console.WriteLine($"Port {uri.Port}");
Console.WriteLine($"Host {uri.Host}");
Console.WriteLine($"Path {uri.AbsolutePath}");
Console.WriteLine($"Query {uri.Query}");

IPHostEntry entry = Dns.GetHostEntry(uri.Host);
Console.WriteLine($"{entry.HostName} has the following IP address: ");


foreach (IPAddress addr in entry.AddressList)
{
    Console.WriteLine($"{addr} {addr.AddressFamily}");
}


try
{
    Ping ping = new();
    Console.WriteLine("Pinging server please wait...");
    PingReply reply = ping.Send(uri.Host);
    Console.WriteLine($"{uri.Host} was pinged and replied: {reply.Status}");
    if(reply.Status == IPStatus.Success)
    {
        Console.WriteLine($"Reply from {reply.Status} took {reply.RoundtripTime:N0}ms");
    }
    
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.GetType} says {ex.Message}");
}