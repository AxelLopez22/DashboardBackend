using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisProjectVersionTable
    {
        public int Id { get; set; }
        public uint ProjectId { get; set; }
        public string Version { get; set; } = null!;
        public string Description { get; set; } = null!;
        public sbyte Released { get; set; }
        public sbyte Obsolete { get; set; }
        public uint DateOrder { get; set; }
    }
}
