using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugHistoryTable
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public uint BugId { get; set; }
        public string FieldName { get; set; } = null!;
        public string OldValue { get; set; } = null!;
        public string NewValue { get; set; } = null!;
        public short Type { get; set; }
        public uint DateModified { get; set; }
    }
}
