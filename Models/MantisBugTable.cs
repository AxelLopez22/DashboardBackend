using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugTable
    {
        public uint Id { get; set; }
        public uint ProjectId { get; set; }
        public uint ReporterId { get; set; }
        public uint HandlerId { get; set; }
        public uint DuplicateId { get; set; }
        public short Priority { get; set; }
        public short Severity { get; set; }
        public short Reproducibility { get; set; }
        public short Status { get; set; }
        public short Resolution { get; set; }
        public short Projection { get; set; }
        public short Eta { get; set; }
        public uint BugTextId { get; set; }
        public string Os { get; set; } = null!;
        public string OsBuild { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public string Version { get; set; } = null!;
        public string FixedInVersion { get; set; } = null!;
        public string Build { get; set; } = null!;
        public uint ProfileId { get; set; }
        public short ViewState { get; set; }
        public string Summary { get; set; } = null!;
        public int SponsorshipTotal { get; set; }
        public sbyte Sticky { get; set; }
        public string TargetVersion { get; set; } = null!;
        public uint CategoryId { get; set; }
        public uint DateSubmitted { get; set; }
        public uint DueDate { get; set; }
        public uint LastUpdated { get; set; }
    }
}
