using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisCategoryTable
    {
        public uint Id { get; set; }
        public uint ProjectId { get; set; }
        public uint UserId { get; set; }
        public string Name { get; set; } = null!;
        public uint Status { get; set; }
    }
}
