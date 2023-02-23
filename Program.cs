// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using System.Text;
using CliWrap;
using Cocona;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Text.Json.Serialization;


var SC_RUNNING = false;

await Cli.Wrap("adb")
   .WithArguments("shell ime disable com.google.android.tts/com.google.android.apps.speech.tts.googletts.settings.asr.voiceime.VoiceInputMethodService")
   .ExecuteAsync();

await Cli.Wrap("adb")
   .WithArguments("shell ime disable com.google.android.inputmethod.latin/com.android.inputmethod.latin.LatinIME")
   .ExecuteAsync();

await Cli.Wrap("adb")
   .WithArguments("shell ime set com.android.adbkeyboard/.AdbIME")
   .ExecuteAsync();

await Glo.OpenInputStatus();

await Glo.SendMessage(string.Empty);


var smsg = new Dictionary<string, string> {
    {"hl" , "哈喽~~~~🤗🤗🤗🤗🤗🤗"},
    {"test1",@"

|￣￣￣￣￣￣￣ |  
|            AFK              |
|＿＿＿＿＿ _＿_|
(\__/) || 
(•ㅅ•) || 
/ 　 づ

".Trim()},
    {"test2",@"

▲
▲ ▲
..(\ /)
..(•.•)  
c("")(“) 

".Trim()},
    {"test3",@"

(\(\
( – -)  AFK
((‘) (’)

".Trim()},
    {"test4",@"

(=‘.’=)
(“)_(”)

".Trim()},
    {"test6",@"

.-..-. /),/) .-..-.
""-.-"" ( ';' ) ""-.-""
.-..-. c(..c) .-..-.
""-.-"" 00 ""-.-""

".Trim()},
    {"test7",@"

(”)….(”)
( ‘ o ‘ )
(”)–(”)
(””’)-(””’)

".Trim()},
    {"test8",@"

(\_/)
( •,•)
("")_("")

".Trim()},
    {"test9",@"

( )  ( )
( o . o)

".Trim()},
    {"test10",@"

".Trim()},
    {"test11",@"

o( ("") ("")

".Trim()},
    {"test12",@"

^. .^
(@).(@)
{ /l l\ }
¥""""¥

".Trim()},
    {"test13",@"

. (＼_／)
٩(◍•౪•◍)۶✧˖°

".Trim()},
    {"test14",@"

".Trim()},
    {"test15",@"

_██_
‹(•¿•)›
..(█)
.../ I

".Trim()},
    {"test16",@"

(•3•)
Z(  )z
/  \

".Trim()},
    {"test17",@"

|(•)
- )
|(•)

".Trim()},
    {"test18",@"

(n_n)_)_)_)_)_)_)_)_)

".Trim()},
    {"test19",@"

Sniper Rifle ▄︻̷̿┻̿═━一

".Trim()},
    {"test20",@"

".Trim()},
    {"test21",@"

Music♩♪♫♬ Volume: ▁ ▃ ▄ ▆ █ 100 %

██▓▒░.___.░▒▓█► Check Back for Updates

".Trim()},
    {"test24",@"

´*•.¸(*•.¸♥¸.•*´)¸.•*´
♥«´¨`•°..诺瑜..°•´¨`»♥
.¸.•*(¸.•*´♥`*•.¸)`*•.

".Trim()},
    {"test22",@"

╔═.♥.══════╗
NAME
╚══════.♥.═╝

".Trim()},
    {"test23",@"

(.   \
\  |   
\ |___(\--/)
__/    (  . . )
""'._.    '-.O.'
'-.  \ ""|\
 '.,,/'.,,mrf

".Trim()}};

var rep = new Dictionary<string, string>
{

};


string MSG = null;
Task? player = default;
var playerCancellationTokenSource = new CancellationTokenSource();


Console.CancelKeyPress += async delegate
{
    if (SC_RUNNING)
    {
        return;
    }

    Cli.Wrap("adb")
        .WithArguments("shell ime enable com.google.android.inputmethod.latin/com.android.inputmethod.latin.LatinIME")
        .ExecuteAsync()
        .Task
        .Wait();

    Cli.Wrap("adb")
        .WithArguments("shell ime enable com.google.android.tts/com.google.android.apps.speech.tts.googletts.settings.asr.voiceime.VoiceInputMethodService")
        .ExecuteAsync()
        .Task
        .Wait();

    Cli.Wrap("adb")
        .WithArguments("shell ime set com.google.android.inputmethod.latin/com.android.inputmethod.latin.LatinIME")
        .ExecuteAsync()
        .Task
        .Wait();

    await new Player().Stop();
};

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

string speechKey = "02f8af1888614a2d9571b09c7d5a76b1";
string speechRegion = "eastasia";

void OutputSpeechRecognitionResult(SpeechRecognitionResult speechRecognitionResult)
{
    switch (speechRecognitionResult.Reason)
    {
        case ResultReason.RecognizedSpeech:
            MSG = speechRecognitionResult.Text;
            break;
        case ResultReason.NoMatch:
            Console.WriteLine($"NOMATCH: Speech could not be recognized.");
            break;
        case ResultReason.Canceled:
            var cancellation = CancellationDetails.FromResult(speechRecognitionResult);
            Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

            if (cancellation.Reason == CancellationReason.Error)
            {
                Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
            }
            break;
    }
}




async Task ReadFromMic()
{
    MSG = null;
    var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
    speechConfig.SpeechRecognitionLanguage = "zh-CN";
    using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
    using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);


    var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
    OutputSpeechRecognitionResult(speechRecognitionResult);
}

while (true)
{
    Console.Write("> ");

    var msg = Console.ReadLine();

    if (msg is null)
    {
        continue;
    }

    if (msg.StartsWith("sc "))
    {
        var myArgs = msg.Split(" ")[1..];
        SC_RUNNING = true;
        await CoconaApp.RunAsync<SystemCall>(myArgs);
        SC_RUNNING = false;
        continue;
    }

    if (smsg.TryGetValue(msg, out var tm))
    {
        Console.WriteLine(tm);
        msg = tm;
    }

    if (string.IsNullOrWhiteSpace(msg))
    {
        await Glo.OpenInputStatus();

        var readFromMic = ReadFromMic();
        Console.Write("Speak into your microphone.");

        var index = 0;

        while (!readFromMic.IsCompleted)
        {
            if (index < 6)
            {
                Console.Write(".");
                index++;
            }
            else
            {
                index = 0;
                Console.CursorLeft -= 6;
                Console.Write("      ");
                Console.CursorLeft -= 6;
            }

            await Task.Delay(100);
        }

        Console.WriteLine();
        msg = MSG;

        if (msg is not null)
            Console.WriteLine(msg);
    }


    if (string.IsNullOrWhiteSpace(msg))
    {
        Console.WriteLine("Speak cencel");
        continue;
    }



    var task = Task.Run(() => Glo.SendMessage(msg));

    var i = 0;

    while (!task.IsCompleted)
    {
        Console.Write(".");
        i++;
        await Task.Delay(100);
    }

    for (; i < 30; i++)
    {
        Console.Write(".");
    }

    Console.WriteLine();
}
