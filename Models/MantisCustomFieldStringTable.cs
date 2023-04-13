using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisCustomFieldStringTable
    {
        public int FieldId { get; set; }
        public int BugId { get; set; }
        public string Value { get; set; } = null!;
        public string? Text { get; set; }
    }
}
