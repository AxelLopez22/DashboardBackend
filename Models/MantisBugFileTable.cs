using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisBugFileTable
    {
        public uint Id { get; set; }
        public uint BugId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Diskfile { get; set; } = null!;
        public string Filename { get; set; } = null!;
        public string Folder { get; set; } = null!;
        public int Filesize { get; set; }
        public string FileType { get; set; } = null!;
        public byte[]? Content { get; set; }
        public uint DateAdded { get; set; }
        public uint UserId { get; set; }
    }
}
