using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisNewsTable
    {
        public uint Id { get; set; }
        public uint ProjectId { get; set; }
        public uint PosterId { get; set; }
        public short ViewState { get; set; }
        public sbyte Announcement { get; set; }
        public string Headline { get; set; } = null!;
        public string Body { get; set; } = null!;
        public uint LastModified { get; set; }
        public uint DatePosted { get; set; }
    }
}
