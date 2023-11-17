using static ProjectTestApi.Models.ApiDetailModel;

namespace ProjectTestApi.Models
{
    public class ApiRelatedNewModel
    {
        public string? tieude { get; set; }
        public string? xemthem { get; set; }
        public string? tenham { get; set; }
        public string? url { get; set; }
        public List<BaiViet>? baiviet { get; set; }
        public class BaiViet
        {
            public string? id { get; set; }
            public string? loaitin { get;set; }
            public string? url { get; set; }
            public string? tieude { get; set; }
            public string? tenND { get; set; }
            public string? diachiND { get;set; }
            public string? emailND { get; set; }
            public string? emailxxxND { get; set; }
            public List<YeuCauKyNang>? yeucaukynang { get; set; }
            public List<NganhHoc>? nganhhoc { get; set; }
            public List<HeDaoTao>? hedaotao { get; set; }
            public List<DiaChiMap>? diachimap { get; set; }
            public List<Tinh>? tinh { get; set; }
        }
        public class YeuCauKyNang
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class NganhHoc
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class HeDaoTao
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class DiaChiMap
        {
            public string? tengoi { get; set; }
            public string? toadox { get; set; }
            public string? toadoy { get; set; }
        }
        public class Tinh
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
    }
}
