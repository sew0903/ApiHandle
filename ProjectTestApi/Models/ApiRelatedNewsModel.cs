namespace ProjectTestApi.Models
{
    public class ApiRelatedNewsModel
    {
        public string? tieude { get;set; }
        public string? xemthem { get;set; }
        public string? tenham { get;set; }
        public string? url { get;set; }
        public List<BaiViet>? baiviet { get;set; }
        public class BaiViet
        {
            public string? id { get;set; }
            public string? url { get; set; }
            public string? ngaydang { get; set; }
            public string? hinhdaidien { get; set;}
            public string? tieude { get; set; }
            public string? noidungtomtat { get; set; }
        }
    }
}
