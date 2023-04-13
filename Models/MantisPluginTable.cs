using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisPluginTable
    {
        public string Basename { get; set; } = null!;
        public sbyte Enabled { get; set; }
        public sbyte Protected { get; set; }
        public uint Priority { get; set; }
    }
}
