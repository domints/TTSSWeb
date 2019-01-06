using TTSSLib.Models.Enums;

namespace TTSSWeb.Models
{
    public class TripPassageListItem
    {
        public static TripPassageListItem FromLibModel(TTSSLib.Models.Data.TripPassage passage, bool isOld = false)
        {
            return new TripPassageListItem {
                ActualTime = passage.ActualTime.ToString("hh\\:mm"),
                StopId = passage.StopId,
                StopName = passage.StopName,
                IsOld = isOld || passage.Status == PassageStatus.Departed,
                IsStopping = passage.Status == PassageStatus.Stopping,
                SeqNumber = passage.SeqNumber
            };
        }

        public string ActualTime { get; set; }
        public string StopId { get; set; }
        public string StopName { get; set; }
        public int SeqNumber { get; set; }
        public bool IsOld { get; set; }
        public bool IsStopping { get; set; }

    }
}