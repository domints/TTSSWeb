using System.Collections.Generic;
using System.Linq;

namespace TTSSWeb.Models
{
    public class TripPassages
    {
        public static TripPassages FromLibModel(TTSSLib.Models.Data.TripPassages passages)
        {
            var result = new TripPassages {
                Line = passages.RouteName,
                Direction = passages.Direction
            };

            result.ListItems = new List<TripPassageListItem>(
                passages.OldPassages.Select(p => TripPassageListItem.FromLibModel(p, isOld: true))
                    .Concat(passages.ActualPassages
                        .Select(p => TripPassageListItem.FromLibModel(p)))
                    .OrderBy(p => p.SeqNumber)
            );

            return result;
        }

        public string Line { get; set; }
        public string Direction { get; set; }
        public List<TripPassageListItem> ListItems { get; set; }
    }
}