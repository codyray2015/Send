using System.Text;
using CliWrap;
using CliWrap.Buffered;
using Cocona;


public class Player
{
    public static CancellationTokenSource? CancellationTokenSource;

    public static Task? Running;

    [Command("play")]
    Task Play([Argument] int startWith = 0)
    {
        if (Running is not null && !Running.IsCompleted)
        {
            CancellationTokenSource!.Cancel();
        }

        CancellationTokenSource = new CancellationTokenSource();
        Running = Cli.Wrap("COTLTracker/player")
            .WithArguments(@"-track ./COTLTracker/tracks/34首串烧.txt")
            .ExecuteAsync(CancellationTokenSource.Token);

        return Task.CompletedTask;
    }

    [Command("stop")]
    public Task Stop()
    {
        if (Running is not null && !Running.IsCompleted)
        {
            CancellationTokenSource!.Cancel();
        }

        return Task.CompletedTask;
    }



}