namespace ProjectTestApi.Models
{
    public class BoLocModel
    {
        public string? id { get; set; }
        public string? url { get; set; }
        public string? ten { get; set; }
        public string? ma { get; set; }
        public NoiDungForm? noidungform {  get; set; }
        public List<ThamSoDetail>? thamso { get; set; }
        public class NoiDungForm
        {
            public string? id { get; set; }
            public string? idquanly { get; set; }
            public string? danhmuc { get; set; }
            public string? idxuly { get; set; }
            public string? tieude { get; set; }
            public string? chonnhieu { get; set; }
            public string? url { get; set; }
            //public GiaTriDetail giatri { get; set;}
            public string? tennhom { get; set; }
            public string? nhom { get; set; }
        }
        public class ThamSoDetail
        {
            public string? tengoi { get; set; }
            public string? ma { get; set; }
            public string? url { get; set; }

        }
    }
}
