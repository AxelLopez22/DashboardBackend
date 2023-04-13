using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugnoteTextTable
    {
        public uint Id { get; set; }
        public string Note { get; set; } = null!;
    }
}
