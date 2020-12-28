using System;
using System.Net;

namespace WebIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello WebClient!");

            // Create new webclient
            WebClient client = new WebClient();
            
            // Optional: Set user agent - to pretend we are a google chrome browser
            //client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 Edg/87.0.664.66");
            
            // Download data as string from given address (http: ....)
            string webseite = client.DownloadString("https://www.innsbruck.gv.at/data.cfm?vpath=diverse/ogd/statistik9/wetter/monatsmitteltemperaturen-seit-1906csv");
            
            // Print data loaded from website
            Console.WriteLine(webseite);

            // Download data as byte stream and store to array
            byte[] receivedData = client.DownloadData("http://intranet.ooelfv.at/webext2/rss/json_6stunden.txt");

            // Iterate through byte array
            for (int i = 0; i < receivedData.Length; i++)
            {
                // Print each byte as char
                Console.Write((char) receivedData[i]);
            }

            // Download data and store in file
            Console.WriteLine("Starting download ...");
            try
            {
                string fileURI = "https://upload.wikimedia.org/wikipedia/commons/c/c6/Pied_kingfisher_%28Ceryle_rudis_rudis%29_female_2.jpg";
                
                // download from given address and store to local file
                client.DownloadFile(fileURI, "vogel.jpg");
                Console.WriteLine("Download completed.");
            }
            catch (Exception e)
            {
                // Error message if download fails.
                Console.WriteLine("Download failed: " + e.Message);
            }
            


        }
    }
}
