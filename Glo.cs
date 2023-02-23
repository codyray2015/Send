
using CliWrap;

public static class Glo
{
    public static string Template = "{{MESSAGE}}";

    public static Dictionary<string, string> ReplaceText = new(){
        {"你妈","阿姨"}

    };

    public async static Task SendMessage(string msg)
    {
        msg = Template.Replace("{{MESSAGE}}", msg);
        // msg = msg.Replace("你","诺");

        foreach (var item in ReplaceText)
        {
            msg = msg.Replace(item.Key, item.Value);
        }

        await Cli.Wrap("adb")
            .WithArguments("shell am broadcast -a ADB_CLEAR_TEXT")
            .ExecuteAsync();

        await Cli.Wrap("adb")
            .WithArguments($"shell am broadcast -a ADB_INPUT_B64 --es msg '{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(msg))}'")
            .ExecuteAsync();

        await Cli.Wrap("adb")
            .WithArguments($"shell am broadcast -a ADB_EDITOR_CODE --ei code 4")
            .ExecuteAsync();

        await Cli.Wrap("adb")
            .WithArguments($"shell input keyevent 66")
            .ExecuteAsync();
    }

    public static async Task OpenInputStatus()
    {
        await Cli.Wrap("adb")
            .WithArguments("shell su -c 'sendevent /dev/input/event3 1 314 1;sleep 0.5;input keyevent 4'")
            .ExecuteAsync();
    }

}
