using System.Collections.Generic;

namespace TTSSLib.Models.Data
{
    public class TripPassages
    {
        public string Direction { get; set; }
        public string RouteName { get; set; }
        public List<TripPassage> ActualPassages { get; set; }
        public List<TripPassage> OldPassages { get; set; }
    }
}