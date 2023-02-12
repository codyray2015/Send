// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using System.Text;
using CliWrap;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

// Console.WriteLine();

var smsg = new Dictionary<string,string> {
    {"hl" , "哈喽~~~~🤗🤗🤗🤗🤗🤗"}
};

string MSG = null;
Task? player = default;
var playerCancellationTokenSource = new CancellationTokenSource();


Console.CancelKeyPress += delegate
{
    playerCancellationTokenSource.Cancel();

    while (!(player?.IsCompleted ?? true))
    { }
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

    if (msg.StartsWith("playlist"))
    {
        foreach (var item in Directory.GetFiles("./COTLTracker/tracks", "*.txt"))
        {
            Console.WriteLine(new FileInfo(item).Name[..^4]);
        }
        Console.WriteLine("..............................");
        continue;
    }

    // if (msg.StartsWith("play "))
    // {
    //     Play(msg.Split(" ").Last());
    //     Console.WriteLine("..............................");
    //     continue;
    // }

    if(smsg.TryGetValue(msg,out var tm)){
        Console.WriteLine(tm);
        msg = tm;
    }

    if (string.IsNullOrWhiteSpace(msg))
    {
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



    var task = Task.Run(() => SendMessage(msg));

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

// void Play(string name)
// {
//     File.WriteAllText("player.bat",@$"
//         cd COTLTracker
//         go run main.go -track ./tracks/{name}.txt
//     ",);

//     Process.Start(new ProcessStartInfo("player.bat")
//     {
//         CreateNoWindow = true,
//         UseShellExecute = false
//     });


//     // player = Cli.Wrap("go")
//     //    .WithArguments("run main.go -track " + name)
//     //    .WithWorkingDirectory("./COTLTracker/")
//     //    .WithStandardOutputPipe(PipeTarget.Create((stream =>
//     //    {

//     //    })))
//     //    .ExecuteAsync(playerCancellationTokenSource.Token);


// }

void SendMessage(string msg)
{
    File.WriteAllLines("run.bat", new string[] {
$"adb shell am broadcast -a ADB_CLEAR_TEXT",
$"adb shell am broadcast -a ADB_INPUT_B64 --es msg '{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(msg))}'",
$"adb shell am broadcast -a ADB_EDITOR_CODE --ei code 4"
});

    Process.Start(new ProcessStartInfo("run.bat")
    {
        CreateNoWindow = true,
        UseShellExecute = false
    });
}


