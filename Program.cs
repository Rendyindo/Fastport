using System;
using System.Net;
using System.IO;

namespace fastport
{
    class Init
    {
        static void Main(string[] args) {
            Console.WriteLine(" ----- Fastport for MT6580 -----"); // basically introduction lol
            Console.WriteLine(" -----     by RendyAK      -----");
            new Helper().getUpdate();
            
        }
    }

    class Helper
    {
        public void getUpdate() {
            Console.WriteLine("Checking for update...");
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
        }
    }
}