using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisTagTable
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public uint DateCreated { get; set; }
        public uint DateUpdated { get; set; }
    }
}
