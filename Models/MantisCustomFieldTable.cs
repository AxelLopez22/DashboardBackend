using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisCustomFieldTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public short Type { get; set; }
        public string? PossibleValues { get; set; }
        public string DefaultValue { get; set; } = null!;
        public string ValidRegexp { get; set; } = null!;
        public short AccessLevelR { get; set; }
        public short AccessLevelRw { get; set; }
        public int LengthMin { get; set; }
        public int LengthMax { get; set; }
        public sbyte RequireReport { get; set; }
        public sbyte RequireUpdate { get; set; }
        public sbyte DisplayReport { get; set; }
        public sbyte DisplayUpdate { get; set; }
        public sbyte RequireResolved { get; set; }
        public sbyte DisplayResolved { get; set; }
        public sbyte DisplayClosed { get; set; }
        public sbyte RequireClosed { get; set; }
        public sbyte FilterBy { get; set; }
    }
}
