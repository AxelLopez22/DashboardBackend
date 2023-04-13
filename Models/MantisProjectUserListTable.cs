using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisProjectUserListTable
    {
        public uint ProjectId { get; set; }
        public uint UserId { get; set; }
        public short AccessLevel { get; set; }
    }
}
