using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisCustomFieldProjectTable
    {
        public int FieldId { get; set; }
        public uint ProjectId { get; set; }
        public short Sequence { get; set; }
    }
}
