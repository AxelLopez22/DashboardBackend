using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisApiTokenTable
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Hash { get; set; } = null!;
        public uint DateCreated { get; set; }
        public uint DateUsed { get; set; }
    }
}
