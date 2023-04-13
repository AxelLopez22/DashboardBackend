using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisProjectHierarchyTable
    {
        public uint ChildId { get; set; }
        public uint ParentId { get; set; }
        public sbyte InheritParent { get; set; }
    }
}
