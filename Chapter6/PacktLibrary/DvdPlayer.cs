namespace Packt.Shared;

public class DvdPalyer : IPlayable
{
    public void Pause()
    {
        Console.WriteLine("PAUSE");
    }

    public void Play()
    {
        Console.WriteLine("PLAY");
    }
}