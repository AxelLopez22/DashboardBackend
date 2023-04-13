using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisEmailTable
    {
        public uint EmailId { get; set; }
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Metadata { get; set; } = null!;
        public string Body { get; set; } = null!;
        public uint Submitted { get; set; }
    }
}
