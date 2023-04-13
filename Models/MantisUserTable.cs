using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class MantisUserTable
    {
        public uint Id { get; set; }
        public string Username { get; set; } = null!;
        public string Realname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public sbyte Enabled { get; set; }
        public sbyte Protected { get; set; }
        public short AccessLevel { get; set; }
        public int LoginCount { get; set; }
        public short LostPasswordRequestCount { get; set; }
        public short FailedLoginCount { get; set; }
        public string CookieString { get; set; } = null!;
        public uint LastVisit { get; set; }
        public uint DateCreated { get; set; }
    }
}
