using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace fastport
{
    class Init
    {
        static void Main(string[] args) {
            Console.WriteLine(" ----- Fastport for MT6580 -----"); // basically introduction lol
            Console.WriteLine(" -----     by RendyAK      -----");
            new Helper().getUpdate();
            bool dircheck = Directory.Exists("tools");
            if(!dircheck)
            {
                Console.WriteLine("! Tools folder not found, exiting...");
                Console.ReadKey();
                Environment.Exit(404);
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please select one of porting methods:");
            Console.WriteLine("1. Same chipset port");
            Console.WriteLine("2. Crossport");
            Console.Write("Answer: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice) {
                case 1:
                    new Helper().schipset();
                    break;
                case 2:
                    Console.WriteLine("Not yet");
                    break;
            }
        }
    }

    class Helper
    {
        public void getUpdate() {
            Console.WriteLine("Checking for update...");
            try {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://raw.githubusercontent.com/Rendyindo/Fastport/master/version");
                StreamReader reader = new StreamReader(stream);
                float content = float.Parse(reader.ReadToEnd());
                StreamReader file = new StreamReader("ver");
                float line = float.Parse(file.ReadLine());
                if(content > line) {
                    Console.WriteLine("Update found: {0}", content);
                    client.DownloadFile("http://example.com/file/song/a.mpeg", "a.mpeg");
                } else {
                    Console.WriteLine("No update found.");
                }
            } catch (WebException) {
                Console.WriteLine("! Warning, couldn't get latest version info from Github !");
            }
        }

        public void schipset() {
            Console.WriteLine("Please select ROM folder you wanted to port");
            String selected = askFolder();
            Console.WriteLine("You picked {0}", selected);
            getStockROM();
        }

        public string askFolder() {
                var proc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "tools/select.bat",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            string selected = proc.StandardOutput.ReadToEnd();
            return selected;
        }

        public void getStockROM() {
            Console.WriteLine("Please select a method to get your stock ROM");
            Console.WriteLine("1. adb");
            Console.WriteLine("2. Stock ROM (system.img/system.new.dat/system)");
            Console.Write("Answer:");
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option) {
                case 1:
                    getStockFromadb();
                    break;
                case 2:
                    getStockFromFolder();
                    break;
            }
        }

        public void getStockFromadb() {
            
        }
    }
}