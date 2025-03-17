using Alachisoft.NCache.Client;
using CodeBehind.TiroCurto.FaladorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Speech.Synthesis;
using static System.Net.Mime.MediaTypeNames;

namespace CodeBehind.TiroCurto.FaladorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*
            Installation Key: EBe398Y2MHeQ9/a2sJBQQYD3AyKjAgKnl5fnpwFT82OjA0KXs2NzFta2N/ZFxAU1ZQXFJWSlRPVlIAAkADBx4eRhoTE=

            Your Email: verij15405@dmener.com
            Your Name: Veri Rajdi

            Key Issue Date: March 17, 2025
            Key Expiration: April 16, 2025
            Orig Key Recipient: verij15405@dmener.com
            Key Customer Domain: dmener.com

         */
        public IActionResult Index()
        {
            string cacheId = "demoLocalCache";

            // Here you get cache handle by initializing cache
            ICache cache = CacheManager.GetCache(cacheId);
            
            cache.Clear();

            CacheItem cacheItem = new CacheItem("fulano da silva");

            // Cache is a key-value store.
            // Every cache item is uniquely identified by its cache key.
            string cacheKey = $"nome";

            // To put an item into the cache, you can use both Add and Insert methods
            cache.Add(cacheKey, cacheItem);


            return View();
        }

        public IActionResult ChamadaLocal()
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.SetOutputToDefaultAudioDevice(); // Usa o dispositivo de áudio padrão
                synthesizer.Speak("Ola mundo"); // Reproduz o texto como áudio
            }

            return View();
        }

        public IActionResult ChamadaConsole()
        {

            string exePath = @"C:\GIT\tirocurto\CodeBehind\CodeBehind.TiroCurto.Falador\bin\Debug\net8.0\CodeBehind.TiroCurto.Falador.exe"; // Altere para o caminho do seu executável

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = $"\"Ola mundo console\"",
                RedirectStandardOutput = true, // Captura a saída do console
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd(); // Lê a saída padrão
                string error = process.StandardError.ReadToEnd();  // Lê possíveis erros
                process.WaitForExit();
            }

            return View();
        }

        public IActionResult ChamadaRemota()
        {
            //tem no cache?
            // Set the name of the cache your application needs to talk to
            string cacheId = "demoLocalCache";

            // Here you get cache handle by initializing cache
            ICache cache = CacheManager.GetCache(cacheId);

            var nome = cache.Get<string>("nome");

            if (!string.IsNullOrEmpty(nome))
            {
                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.SetOutputToDefaultAudioDevice(); // Usa o dispositivo de áudio padrão
                    synthesizer.Speak(nome); // Reproduz o texto como áudio
                }

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
