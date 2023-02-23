// See https://aka.ms/new-console-template for more information


using CliWrap;
using Cocona;
using System.Net.Http.Json;

public class YuLu
{
    [Command("chp", Description = "彩虹屁生成器")]
    async Task CaiHongPi([Argument] int? count, [Option("s", Description = "仅列出内容,不发送")] bool? simple)
    {
        count ??= 1;

        for (int i = 0; i < count; i++)
        {
            var msg = await new HttpClient().GetFromJsonAsync<Shadiao>("https://api.shadiao.pro/chp");
            Console.WriteLine(msg.Data.Text);
            if (!(simple ?? false))
            {
                await Glo.SendMessage(msg.Data.Text);
            }
        }
    }

    [Command("djt", Description = "毒鸡汤生成器")]
    async Task DuJiTang([Argument] int? count, [Option("s", Description = "仅列出内容,不发送")] bool? simple)
    {
        count ??= 1;

        for (int i = 0; i < count; i++)
        {
            var msg = await new HttpClient().GetFromJsonAsync<Shadiao>("https://api.shadiao.pro/du");
            Console.WriteLine(msg.Data.Text);
            if (!(simple ?? false))
            {
                await Glo.SendMessage(msg.Data.Text);
            }
        }
    }

    [Command("pyq", Description = "朋友圈语录生成器")]
    async Task PengYouQuan([Argument] int? count, [Option("s", Description = "仅列出内容,不发送")] bool? simple)
    {
        count ??= 1;
        for (int i = 0; i < count; i++)
        {
            var msg = await new HttpClient().GetFromJsonAsync<Shadiao>("https://api.shadiao.pro/pyq");
            Console.WriteLine(msg.Data.Text);
            if (!(simple ?? false))
            {
                await Glo.SendMessage(msg.Data.Text);
            }
        }
    }

    [Command("dz", Description = "网易云段子库")]
    async Task DuanZi([Argument] int? count, [Option("s", Description = "仅列出内容,不发送")] bool? simple)
    {
        count ??= 1;
        for (int i = 0; i < count; i++)
        {
            var msg = await new HttpClient().GetFromJsonAsync<WangYiYunDuanZi>("https://www.yduanzi.com/duanzi/getduanzi");
            var msgStr = msg.Duanzi.Replace("<br>", "\r\n");
            Console.WriteLine(msgStr);
            if (!(simple ?? false))
            {
                await Glo.SendMessage(msgStr);
            }
        }
    }

    [Command("gh", Description = "赶海-海王库")]
    async Task ZhaNan([Argument] int? count, [Option("s", Description = "仅列出内容,不发送")] bool? simple)
    {
        count ??= 1;
        for (int i = 0; i < count; i++)
        {
            var msg = await new HttpClient().GetFromJsonAsync<SweetNothings>("https://api.lovelive.tools/api/SweetNothings/Web/1");
            var msgStr = msg.ReturnObj.Content;
            Console.WriteLine(msgStr);
            if (!(simple ?? false))
            {
                await Glo.SendMessage(msgStr);
            }
        }
    }

    [Command("hc", Description = "喝茶-绿茶库")]
    async Task ZhaNv([Argument] int? count, [Option("s", Description = "仅列出内容,不发送")] bool? simple)
    {
        count ??= 1;
        for (int i = 0; i < count; i++)
        {
            var msg = await new HttpClient().GetFromJsonAsync<SweetNothings>("https://api.lovelive.tools/api/SweetNothings/Web/0");
            var msgStr = msg.ReturnObj.Content;
            Console.WriteLine(msgStr);
            if (!(simple ?? false))
            {
                await Glo.SendMessage(msgStr);
            }
        }
    }

    readonly static string[] TG_LIB = System.Text.Json.JsonSerializer.Deserialize<string[]>(File.OpenRead("tiango.json"));

    [Command("tg", Description = "舔狗库")]
    async Task TianGou([Argument] int count = 1, [Option("s", Description = "仅列出内容,不发送")] bool simple = false)
    {
        for (int i = 0; i < count; i++)
        {
            var msgStr = TG_LIB[Random.Shared.Next(0, TG_LIB.Length - 1)];
            Console.WriteLine(msgStr);
            if (!simple)
            {
                await Glo.SendMessage(msgStr);
            }
        }
    }
}
