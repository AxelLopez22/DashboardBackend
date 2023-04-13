using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisSponsorshipTable
    {
        public int Id { get; set; }
        public int BugId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public string Logo { get; set; } = null!;
        public string Url { get; set; } = null!;
        public sbyte Paid { get; set; }
        public uint DateSubmitted { get; set; }
        public uint LastUpdated { get; set; }
    }
}
