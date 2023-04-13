using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisUserProfileTable
    {
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public string Platform { get; set; } = null!;
        public string Os { get; set; } = null!;
        public string OsBuild { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
