using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugnoteTable
    {
        public uint Id { get; set; }
        public uint BugId { get; set; }
        public uint ReporterId { get; set; }
        public uint BugnoteTextId { get; set; }
        public short ViewState { get; set; }
        public int? NoteType { get; set; }
        public string? NoteAttr { get; set; }
        public uint TimeTracking { get; set; }
        public uint LastModified { get; set; }
        public uint DateSubmitted { get; set; }
    }
}
