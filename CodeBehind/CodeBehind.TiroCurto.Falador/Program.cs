using System;
using System.Speech.Synthesis;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {        
        if (args.Length == 0)
        {
            Console.WriteLine("Nenhum texto informado.");
            return;
        }

        using (SpeechSynthesizer synth = new SpeechSynthesizer())
        {
            Console.WriteLine("Vozes instaladas no sistema:");

            foreach (var voice in synth.GetInstalledVoices())
            {
                Console.WriteLine($" - {voice.VoiceInfo.Name}");
            }
        }
        
        //Microsoft Maria Desktop
        //Microsoft Zira Desktop

        Console.WriteLine($"Reproduzindo o texto {args[0]}");

        using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
        {
            synthesizer.SelectVoice("Microsoft Maria Desktop");     

            synthesizer.SetOutputToDefaultAudioDevice(); // Usa o dispositivo de áudio padrão
            synthesizer.Speak(args[0]);
        }

        Console.WriteLine($"Fim");

        Thread.Sleep(2000);        
    }
}
