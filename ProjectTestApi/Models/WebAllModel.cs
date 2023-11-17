namespace ProjectTestApi.Models
{
    public class WebAllModel
    {
        public string? id { get; set; }
        public string? idxuly { get; set; }
        public string? module { get; set; }
        public string? tenham { get; set; }
        public string? tieude { get; set; }
        public string? metatitle { get; set; }
        public string? metakeywords { get; set; }
        public string? metadescriptions { get; set; }
        public string? url { get; set; }
        public List<NoiDungTab>? noidungtab { get; set; }
        public class NoiDungTab
        {
            public string? id { get; set;}
            public string? tieude { get; set;}
            public string? url { get; set; }
        }
    }
}
