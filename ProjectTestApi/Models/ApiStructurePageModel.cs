namespace ProjectTestApi.Models
{
    public class ApiStructurePageModel
    {      
       public string? idpart { get; set; }
        public bool? ViTriTrai { get; set; }
        public bool? ViTriPhai { get; set; }
        public string? idquanly { get; set; }
       public string? module { get; set; }
       public string? tenham { get; set; }
        public string? hinhdaidien { get; set; }
        public string? tieude { get; set; }
        public string? url { get; set; }
        public string? tomtat { get; set; }
        public List<DanhMucMenu>? danhmucmenu { get; set; }
        public class DanhMucMenu
        {
            public string? idpart { get; set; }
            public string? hinhdaidien { get; set; }
            public string? tieude { get; set; }
            public string? url { get; set; }
        }

    }
}
