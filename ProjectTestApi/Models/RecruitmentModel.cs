namespace ProjectTestApi.Models
{
    public class RecruitmentModel
    {
        public string id { get; set; }
        public string loaitin { get; set; }
        public string url { get; set; }
        public string tieude { get; set; }
        public List<ChucDanhDetail> chucdanh { get; set; }
        public List<NganhDetail> nganh { get; set; }
        public List<DiaChiMapDetail> diachimap { get; set; }
        public List<TinhDetail> tinh { get; set; }
        public string thoihan { get; set; }
        public List<GiaDetail> gia { get; set; }
        public string hinhdaidien { get; set; }
        public string tenND { get; set; }
        public string diachiND { get; set; }
        public string emailND { get; set; }
        public string emailxxxND { get; set; }
        public class ChucDanhDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class NganhDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class DiaChiMapDetail
        {
            public string? tengoi { get; set; }
            public string? toadox { get; set; }
            public string? toadoy { get; set; }
        }
        public class TinhDetail
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
