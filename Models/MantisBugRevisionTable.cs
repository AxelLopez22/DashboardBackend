using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugRevisionTable
    {
        public uint Id { get; set; }
        public uint BugId { get; set; }
        public uint BugnoteId { get; set; }
        public uint UserId { get; set; }
        public uint Type { get; set; }
        public string Value { get; set; } = null!;
        public uint Timestamp { get; set; }
    }
}
