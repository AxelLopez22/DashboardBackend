using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugTagTable
    {
        public uint BugId { get; set; }
        public uint TagId { get; set; }
        public uint UserId { get; set; }
        public uint DateAttached { get; set; }
    }
}
