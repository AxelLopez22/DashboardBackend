using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisConfigTable
    {
        public string ConfigId { get; set; } = null!;
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int? AccessReqd { get; set; }
        public int? Type { get; set; }
        public string Value { get; set; } = null!;
    }
}
