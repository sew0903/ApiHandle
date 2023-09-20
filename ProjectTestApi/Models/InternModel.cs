namespace ProjectTestApi.Models
{
    public class InternModel
    {
        public string id { get; set; }
        public string loaitin { get; set; }   
        public string url { get; set; }
        public string tieude { get; set; }
        public string hinhdaidien { get; set; }
        public List<LoaiDetai> loai { get; set; }
        public List<NganhDetai> nganh { get; set; }
        public List<TinhDetai> tinh { get; set; }
        public List<GiaDetail> gia { get; set; }
        public string tenND { get; set; }
        public class LoaiDetai
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class NganhDetai
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class TinhDetai
        {
            public string? tengoi { get; set; }
            public string? huyen { get; set; }
            public string? url { get; set; }
        }
        public class GiaDetail
        {
            public string? sotien { get; set; }
            public string? viet { get; set; }
            public string? donvi { get; set; }
        }

    }
}
