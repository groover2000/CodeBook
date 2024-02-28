using static System.Console;
using System.Diagnostics;


static void MethodA()
{
    lock (SharedObjects.Conch)
    {


        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(SharedObjects.Random.Next(2000));
            SharedObjects.Message += "A";
            Interlocked.Increment(ref SharedObjects.Counter);
            Write(".");
        }
    }
}
static void MethodB()
{
    lock (SharedObjects.Conch)
    {


        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(SharedObjects.Random.Next(2000));
            SharedObjects.Message += "B";
            Interlocked.Increment(ref SharedObjects.Counter);
            Write(".");
        }
    }
}

WriteLine("Please wait for the tasks to complete.");
Stopwatch watch = Stopwatch.StartNew();
Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);
Task.WaitAll(new Task[] { a, b });
WriteLine();
WriteLine($"Results: {SharedObjects.Message}.");
WriteLine($"{watch.ElapsedMilliseconds:N0} elapsed milliseconds.");
WriteLine($"{SharedObjects.Counter} string modifications.");
static class SharedObjects
{
    public static Random Random = new();
    public static string? Message; // общий ресурс
    public static object Conch = new();
    public static int Counter;
}
