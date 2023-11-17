﻿namespace ProjectTestApi.Models
{
    public class TopMenuModel
    {
        public string? idpart { get; set; }
        public string? idquanly { get; set; }
        public string? kieuhienthi { get; set; }
        public string? hinhdaidien { get; set; }
        public string? tieude { get; set; }
        public string? url { get; set; }
        public string? module { get; set; }
        public string? tomtat { get; set; }
        public string? tenham { get; set; }
        public List<MenuCap1>? menucap1 { get; set; }
        public class MenuCap1
        {
            public string tieude { get; set;}
            public string url { get; set;}
        }
    }
}
