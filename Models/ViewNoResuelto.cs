﻿using System;
using System.Collections.Generic;

namespace DashboardApi.Models
{
    public partial class ViewNoResuelto
    {
        public uint C { get; set; }
        public string Username { get; set; } = null!;
        public uint DateSubmitted { get; set; }
        public string Summary { get; set; } = null!;
        public int C0 { get; set; }
    }
}
