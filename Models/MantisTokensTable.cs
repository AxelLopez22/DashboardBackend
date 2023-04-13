using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisTokensTable
    {
        public int Id { get; set; }
        public int Owner { get; set; }
        public int Type { get; set; }
        public string Value { get; set; } = null!;
        public uint Timestamp { get; set; }
        public uint Expiry { get; set; }
    }
}
