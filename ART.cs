using Cocona;


public class ART
{
    [Command(nameof(cm),Description = cm)]
    Task Scm() => Send(cm);

    [Command(nameof(cpdd),Description = cpdd)]
    Task Scpdd() => Send(cpdd);

    [Command(nameof(cpdd2),Description = cpdd2)]
    Task Scpdd2() => Send(cpdd2);

    [Command(nameof(qlx),Description = qlx)]
    Task Sqlx() => Send(qlx);

    [Command(nameof(cat),Description = cat)]
    Task Scat() => Send(cat);

    [Command(nameof(flower),Description = flower)]
    Task Sflower() => Send(flower);

    [Command(nameof(hug),Description = hug)]
    Task Shug() => Send(hug);

    [Command(nameof(magic),Description = magic)]
    Task Smagic() => Send(magic);

    [Command(nameof(cookie),Description = cookie)]
    Task Scookie() => Send(cookie);

    [Command(nameof(kiss),Description = kiss)]
    Task Skiss() => Send(kiss);

    [Command(nameof(lovelove),Description = lovelove)]
    Task Slovelove() => Send(lovelove);

    [Command(nameof(dream),Description = dream)]
    Task Sdream() => Send(dream);

    [Command(nameof(hug2),Description = hug2)]
    Task Shug2() => Send(hug2);

    [Command(nameof(givelove),Description = givelove)]
    Task Sgivelove() => Send(givelove);

    [Command(nameof(art1),Description = art1)]
    Task Sart1() => Send(art1);

    [Command(nameof(art2),Description = art2)]
    Task Sart2() => Send(art2);

    [Command(nameof(art3),Description = art3)]
    Task Sart3() => Send(art3);

    [Command(nameof(art4),Description = art4)]
    Task Sart4() => Send(art4);

    [Command(nameof(art5),Description = art5)]
    Task Sart5() => Send(art5);

    [Command(nameof(art6),Description = art6)]
    Task Sart6() => Send(art6);

    [Command(nameof(art7),Description = art7)]
    Task Sart7() => Send(art7);

    [Command(nameof(good),Description = good)]
    Task Sgood() => Send(good);

    Task Send(string msg) =>
        new Template().Send("default",msg);

    const string cm = @"
{\__/}
( • - •)
/つ 草莓要不要?
    ";

    const string qlx = @"
正在播放《七里香》   
━━━●━━━───── 2:10      
⇆       ◁      ❚❚      ▷        ↻
    ";

    const string cpdd = @"
▛▀  ▛▚  ▛▚ ▛▚ 
▙▄  ▛▘  ▙▞ ▙▞ 
“𝐿𝑜𝑣𝑒𝑦𝑜𝑢𝑓𝑜𝑟𝑒𝑣𝑒𝑟” ... ..";

    const string cpdd2 = @"
爱情经不起等待!
▛▀  ▛▚  ▛▚ ▛▚ 
▙▄  ▛▘  ▙▞ ▙▞ 
“就现在!!!” ... ..";

    const string cat = @"
我在这里放一只猫猫 路过的朋友要是不开心的话可以摸摸它 心情会好很多
　　　　　　 ＿＿
　　　　　／＞　　フ
　　　　　|  　_　 _ l
　 　　　／` ミ＿xノ
　　 　 /　　　 　 |
　　　 /　 ヽ　　 ﾉ
　 　 │　　|　|　|
　／￣|　　 |　|　|
　| (￣ヽ＿_ヽ_)__)
　＼二つ
";

    const string flower = @"
 /\___/\
꒰ ˶• ༝ -˶꒱
./づ~ ✿ *gives flower* 
";

    const string hug = @"
。゜˚ᕱ⑅ᕱ ∧ ∧ 。゜。
。゜ (⑅˘̤ ᵕ˘̤) ˘͈ᵕ ˘͈ )。゜。
";
    const string magic = @"
✿ ͡◕ ᴗ◕)つ━━✫・*。
⊂　　 ノ 　　　・゜+.
しーーＪ　　　°。+ *´¨
";


    const string art1 = @"
˚ ₊ ·̩͙. ᘏ▸◂ᘏ .·̩͙ ₊ ✩ 。
˚ ✩  ꒰ ɞ̴̶̷ ·̮ ɞ̴̶̷ ꒱ 。 ˚
₊˚。 *ଘ_("")("") ₊ ˚ ✩
‘’’’’ꕤ’’’’’’ꕤ’’’’’’’’ꕤ’’’’’’’ꕤ’’
";

    const string art2 = @"
₍ᐢ๑- ˔ -ᐢ₎ ♡ ꒰ how lucky i am,
( っ /￣￣￣/ to have you in my life..꒱
(´　 ＼/＿＿＿/)
";

    const string art3 = @"
♡ ૮₍ °´ ˘ ` ° ₎ა ꒰ even when distant,
\ ￣￣￣\ ⊂ ) our hearts are connected ꒱
(\＿＿＿ \／ `)
";

    const string art4 = @"
  A__A
|  ·ω·。 | ♡
|っ　ｃ|
|　　　| ♡
|　　　|
|　　　| ♡
|　　　|
|　　　|
U￣￣U.
";

    const string cookie = @"
{\__/} · ·̩　 。　 ☆
( •ω•) ＊ 。*　 + · 。
/つ🍪 cookie for u!! ·
";

    const string art5 = @"
(\🎀 (\
( ´•̥  ̯ •̥` )
(nnノ)o
";

    const string art6 = @"
     ∩ ∩
ପ( ๑•ᴗ•๑)ଓ
    (⌒ づ♡
";

    const string kiss = @"
  °* (\(\ ⠀(\ /)
⊹.(๑´³`(⁎˃ᴗ˂⁎)˚. ⊹
°* /⌒つ ⊹O )⊹.°⊹.°*
";

    const string lovelove = @"
⠀*· ∧,,∧  ∧_∧ ·*
'.( 。·ω·)(·ω·。) .'
⠀'· | つ♥と |.·'
⠀⠀⠀' ·。。·ﾟ
";

    const string dream = @"
╭ ◜◝ ͡ ◝ ͡ ◜◝ ╮
♡ ∧＿∧ ＿∧ ♡
♡ (๑･ω･)ω<๑) ♡
♡ /⌒ づ⊂⌒ヽ ♡
 　  ╰ ͜ ͜ ͜ ͜ ╯
O
o
°
〃∩∧＿∧ ♡
⊂⌒（ '·ω·）♡
｀ヽ_っ＿/￣￣￣/
　  　 ＼/＿＿＿/
";

    const string hug2 = @"
 _/)_/)_(\_(\
( * · ̮ ·) · ̮ ·*   )
/⌒ づ⊂⌒  ヽ
";

    const string art7 = @"
⠀  .∧__,,∧
 （   ´·ω·`   ）
⠀ (つ♡と）
⠀  ｕ―ｕ´
";

    const string givelove = @"
‖ ((\
‖๑˘ ³˘)⠀~♡
‖ ⊂ノ
";


    const string good = @"
┈┈┈┈┈┈▕▔╲┈┈┈┈┈┈
┈┈┈┈┈┈┈▏▕┈ⓈⓊⓅⒺⓇ
┈┈┈┈┈┈┈▏▕▂▂▂┈┈┈
▂▂▂▂▂▂╱┈▕▂▂▂▏┈┈
▉▉▉▉▉┈┈┈▕▂▂▂▏┈┈
▉▉▉▉▉┈┈┈▕▂▂▂▏┈┈
▔▔▔▔▔▔╲▂▕▂▂▂▏┈┈
";

    const string happybirthday = @"
╮╭╭╮┏╮┏╮╮╭
┣┫┣┫┣╯┣╯╰┫  ☆
╯╯╯╯╯╯╯╯╰╯╭━┻━╮
┏╮┊┏╮╭╮╮╭╭┻━━━┻╮
┣┫┊┃┃┣┫╰┫┣╮╭╮╭╮┃
┗╯┊┗╯╯╯╰╯┃╰╯╰╯╰┫
━━━━━━━━━╯╳╳╳╳╳╰
";

    public const string afk1 = @"
|￣￣￣￣￣￣￣ |  
|          挂机中           |
|＿＿＿＿＿ _＿_|
(\__/) || 
(•ㅅ•) || 
/ 　 づ
";

    public const string afk2 = @"
()""()  AFK
( -.-)  
(,) )...zzzz
";



}