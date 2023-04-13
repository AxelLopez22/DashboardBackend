using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugTextTable
    {
        public uint Id { get; set; }
        public string Description { get; set; } = null!;
        public string StepsToReproduce { get; set; } = null!;
        public string AdditionalInformation { get; set; } = null!;
    }
}
