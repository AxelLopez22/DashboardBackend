using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisUserPrefTable
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public uint ProjectId { get; set; }
        public uint DefaultProfile { get; set; }
        public uint DefaultProject { get; set; }
        public int RefreshDelay { get; set; }
        public int RedirectDelay { get; set; }
        public string BugnoteOrder { get; set; } = null!;
        public sbyte EmailOnNew { get; set; }
        public sbyte EmailOnAssigned { get; set; }
        public sbyte EmailOnFeedback { get; set; }
        public sbyte EmailOnResolved { get; set; }
        public sbyte EmailOnClosed { get; set; }
        public sbyte EmailOnReopened { get; set; }
        public sbyte EmailOnBugnote { get; set; }
        public sbyte EmailOnStatus { get; set; }
        public sbyte EmailOnPriority { get; set; }
        public short EmailOnPriorityMinSeverity { get; set; }
        public short EmailOnStatusMinSeverity { get; set; }
        public short EmailOnBugnoteMinSeverity { get; set; }
        public short EmailOnReopenedMinSeverity { get; set; }
        public short EmailOnClosedMinSeverity { get; set; }
        public short EmailOnResolvedMinSeverity { get; set; }
        public short EmailOnFeedbackMinSeverity { get; set; }
        public short EmailOnAssignedMinSeverity { get; set; }
        public short EmailOnNewMinSeverity { get; set; }
        public short EmailBugnoteLimit { get; set; }
        public string Language { get; set; } = null!;
        public string Timezone { get; set; } = null!;
    }
}
