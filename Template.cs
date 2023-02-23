// See https://aka.ms/new-console-template for more information


using CliWrap;
using Cocona;

public class Template
{
    private static readonly Dictionary<string, string> TEMPLATES = new(){
        {"default",@"{{MESSAGE}}"},
        {"r1",@"
{\__/}
( • - •)
/つ {{MESSAGE}}
    ".Trim()},{"r2",@"
 /\___/\
꒰ ˶• ༝ -˶꒱
./づ~ {{MESSAGE}} 
    ".Trim()},{"r3",@"
  ♡∩_∩
 （„• ֊ •„)♡
┏━∪∪━━━━━━━━┓
   {{MESSAGE}} 
┗━━━━━━━━━━━┛
    ".Trim()},{"r4",@"
{\__/} · ·̩　 。　 ☆
( •ω•) ＊ 。*　 + · 。
/つ {{MESSAGE}}
    ".Trim()}

    };

    [Command("list")]
    async Task List()
    {
        foreach (var item in TEMPLATES)
        {

            Console.WriteLine($".....{item.Key}.....");
            Console.WriteLine(item.Value.Replace(TEMPLATES["default"], "This is a demo"));
        }
    }

    [Command("reset")]
    async Task Reset()
    {
        Glo.Template = TEMPLATES["default"];
    }

    [Command("set")]
    async Task Set([Argument] string name)
    {
        if (TEMPLATES.TryGetValue(name, out var template))
        {
            Glo.Template = template;
            return;
        }

        Console.WriteLine($"Can't find message template <{name}>");
    }

    [Command("send")]
    public async Task Send([Argument] string name, [Argument] string msg)
    {
        if (!TEMPLATES.TryGetValue(name, out var template))
        {
            Console.WriteLine($"Can't find message template <{name}>");
            return;
        }

        var origin = Glo.Template;
        Glo.Template = template;

        Console.WriteLine(template.Replace("{{MESSAGE}}", msg));
        Console.WriteLine("..............................");
        await Glo.SendMessage(msg);
        Glo.Template = origin;



    }
}
