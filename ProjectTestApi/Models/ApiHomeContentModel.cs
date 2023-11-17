namespace ProjectTestApi.Models
{
    public class ApiHomeContentModel
    {
        public string? idpart { get; set; }
        public string? idquanly { get; set; }
        public string? module { get; set; }
        public string? tenham { get; set; }
        public string? hinhdaidien { get; set; }
        public string? tieude { get; set; }
        public string? url { get; set; }
        public string? tomtat { get; set; }
        public List<NoiDungTab>? noidungtab { get; set; }
        public class NoiDungTab
        {
            public string idpart { get; set;}
            public string tieude { get; set;}
            public string tenham { get; set; }
        }
    }
}
