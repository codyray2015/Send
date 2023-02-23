// See https://aka.ms/new-console-template for more information


using CliWrap;
using CliWrap.EventStream;
using Cocona;
// async Task CancelKey()
// {
//     await Cli.Wrap("adb")
//         .WithArguments("shell su -c 'sendevent /dev/input/event3 1 305 1")
//         .ExecuteAsync();
// }


[HasSubCommands(typeof(Template), Description = "Manage message template")]
[HasSubCommands(typeof(YuLu), "yl", Description = "语录库")]
[HasSubCommands(typeof(ART), "art", Description = "ASCII ART")]
[HasSubCommands(typeof(Player), "player", Description = "ASCII ART")]
public class SystemCall : CoconaConsoleAppBase
{
    [Command("paypass")]
    async Task PayPass()
    {
        await Cli.Wrap("adb")
               .WithArguments("shell input tap 500 1100")
               .ExecuteAsync();

        await Task.Delay(1000);

        await Cli.Wrap("adb")
                .WithArguments("shell input text " + File.ReadAllText("C:/Users/a9860/pass"))
                .ExecuteAsync();

        await Task.Delay(2000);

        await Cli.Wrap("adb")
                .WithArguments("shell input tap 500 2600")
                .ExecuteAsync();
    }

    [Command("minc")]
    async Task MinCamara()
    {
        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 544 2'")
            .ExecuteAsync();

        _ = Task.Run(async () =>
           {
               await Task.Delay(1000);
               await Cli.Wrap("adb")
                .WithArguments("shell su -c 'sendevent /dev/input/event3 1 544 1'")
                .ExecuteAsync();
           });
    }

    [Command("maxc")]
    async Task MaxCamara()
    {
        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 545 2'")
            .ExecuteAsync();

        _ = Task.Run(async () =>
           {
               await Task.Delay(1000);
               await Cli.Wrap("adb")
                .WithArguments("shell su -c 'sendevent /dev/input/event3 1 545 1'")
                .ExecuteAsync();
           });
    }

    [Command("task")]
    async Task Tasks()
    {
        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 546 1'")
            .ExecuteAsync();
    }

    [Command("msg")]
    async Task Messages()
    {
        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 547 1'")
            .ExecuteAsync();
    }


    [Command("ligth")]
    async Task Ligth()
    {
        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 308 2'")
            .ExecuteAsync();

        _ = Task.Run(async () =>
        {
            await Task.Delay(1000);
            await Cli.Wrap("adb")
                .WithArguments("shell su -c 'sendevent /dev/input/event3 1 308 1'")
                .ExecuteAsync();
        });
    }

    [Command("bees")]
    Task Bee([Argument] double time)
    {
        _ = Cli.Wrap("adb")
            .WithArguments($"shell su -c \"for n in `seq 1 {time * 100}`\\;do sendevent /dev/input/event3 1 305 1\\;done\"")
            .ExecuteAsync();

        return Task.CompletedTask;
    }

    [Command("bee")]
    async Task Bee()
    {
        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 305 1'")
            .ExecuteAsync();
    }

    [Command("lbee")]
    async Task LongBee([Argument] int times = 0)
    {
        var append = "'";

        if (times > 0)
        {
            append = $"\\;sleep {1.5 * times}\\; sendevent /dev/input/event3 1 305 1'";
        }

        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 305 2" + append)
            .ExecuteAsync();
    }

    [Command("playlist")]
    async Task PlayList()
    {
        foreach (var item in Directory.GetFiles("./COTLTracker/tracks", "*.txt"))
        {
            Console.WriteLine(new FileInfo(item).Name[..^4]);
        }
        Console.WriteLine("..............................");
    }

    [Command("smr", Description = "设置关键词替换")]
    Task SetMessageReplace([Argument] string target, [Argument] string to)
    {
        Glo.ReplaceText[target] = to;
        return Task.CompletedTask;
    }

    [Command("afk")]
    async Task AFK()
    {

        while (!base.Context.CancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("AFK running.....");

            await new Template().Send("default", Random.Shared.Next(1, 2) switch
            {
                2 => ART.afk1,
                1 => ART.afk2,
                _ => string.Empty
            });

            try
            {
                await Task.Delay(60000, Context.CancellationToken);
            }
            catch (System.Exception) { }
        }
    }

}
