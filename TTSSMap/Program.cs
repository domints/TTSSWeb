using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TTSSMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[D]owload Jacek's data, \n[U]pload to TTSSX");
            var choice = Console.ReadKey();
            Console.WriteLine();
            switch(choice.Key)
            {
                case ConsoleKey.D:
                    DownloadJacek();
                    break;
                case ConsoleKey.U:
                    UploadTTSSX();
                    break;
                default:
                    break;
            }
        }

        static void DownloadJacek()
        {
            var url = "https://mpk.jacekk.net/vehicles/view.php";
            System.Net.WebClient wc = new System.Net.WebClient();
            var response = wc.DownloadString(url);
            var jacekData = JsonConvert.DeserializeObject<List<JacekData>>(response);
            using(var f = new StreamWriter("jacek.csv"))
            {
                foreach(var d in jacekData.OrderByDescending(j => j.Id))
                {
                    if(string.IsNullOrWhiteSpace(d.Number) || string.IsNullOrWhiteSpace(d.Id))
                        continue;
                    if(string.IsNullOrWhiteSpace(d.Letter)) d.Letter = "X";
                    if(string.IsNullOrWhiteSpace(d.Depot)) d.Depot = "X";
                    f.WriteLine($"{d.Id};{d.Line};{d.Depot}{d.Letter}{d.Number}");
                }
                f.Flush();
            }
        }

        static void UploadTTSSX()
        {

        }
    }

    public class JacekData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [JsonProperty("depot")]
        public string Depot { get; set; }

        [JsonProperty("letter")]
        public string Letter { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("verified")]
        public string Verified { get; set; }
    }
}
