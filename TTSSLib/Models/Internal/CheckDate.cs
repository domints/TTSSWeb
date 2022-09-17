using System;

namespace TTSSLib.Models.Internal
{
    /// <summary>
    /// Class containing value indicating if is checked and date of the check.
    /// </summary>
    internal class CheckDate
    {
        public CheckDate(bool check)
        {
            Checked = check;
            Date = DateTime.Now;
        }
        public bool Checked { get; set; }
        public DateTime Date { get; set; }
    }
}
