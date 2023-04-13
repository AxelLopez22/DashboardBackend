using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugRelationshipTable
    {
        public uint Id { get; set; }
        public uint SourceBugId { get; set; }
        public uint DestinationBugId { get; set; }
        public short RelationshipType { get; set; }
    }
}
