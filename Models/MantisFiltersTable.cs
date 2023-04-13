using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisFiltersTable
    {
        public uint Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public sbyte? IsPublic { get; set; }
        public string Name { get; set; } = null!;
        public string FilterString { get; set; } = null!;
    }
}
