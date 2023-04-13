using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisUserPrintPrefTable
    {
        public uint UserId { get; set; }
        public string PrintPref { get; set; } = null!;
    }
}
