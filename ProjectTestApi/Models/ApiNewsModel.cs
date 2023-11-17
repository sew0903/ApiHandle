namespace ProjectTestApi.Models
{
    public class ApiNewsModel
    {
        public string? recordsTotal { get;set; }
        public string? recordsFiltered { get;set; }
        public List<Data>? data { get; set; }
        public class Data
        {
            public string? id { get; set; }
            public string? ngaydang { get; set; }
            public string? hinhdaidien { get; set; }
            public string? tieude { get; set; }
            public string? url { get; set; }
            public string? noidungtomtat { get; set; }
            public string? videocode { get; set; }

        }
    }
}
