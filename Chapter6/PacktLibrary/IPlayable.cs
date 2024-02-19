namespace Packt.Shared;


interface IPlayable
{
    public void Play();
    public void Pause();
    public void Stop()
    {
        Console.WriteLine("STOP");
    }
}