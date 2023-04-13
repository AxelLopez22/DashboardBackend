using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisProjectTable
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public short Status { get; set; }
        public sbyte Enabled { get; set; }
        public short ViewState { get; set; }
        public short AccessMin { get; set; }
        public string FilePath { get; set; } = null!;
        public string Description { get; set; } = null!;
        public uint CategoryId { get; set; }
        public sbyte InheritGlobal { get; set; }
    }
}
