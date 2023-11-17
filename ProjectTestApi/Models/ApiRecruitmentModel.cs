using static ProjectTestApi.Models.ApiModel;

namespace ProjectTestApi.Models
{
    public class ApiRecruitmentModel
    {
        public string? recordsTotal { get; set; }
        public string? recordsFiltered { get; set; }
        public List<Data>? data { get; set; }
        public class Data
        {
            public string? id { get; set; }
            public string? loaitin { get; set; }
            public string? url { get; set; }
            public string? tieude { get; set; }
            public string? tenND { get; set; }
            public string? diachiND { get; set; }
            public string? emailND { get; set; }
            public string? emailxxxND { get; set; }
            public string? thoihan { get; set; }
            public List<YeuCauKyNang>? yeucaukynang { get; set; }
            public List<NganhHoc>? nganhhoc { get; set; }
            public List<HeDaoTao>? hedaotao { get; set; }
            public List<DiaChiMap>? diachimap { get; set; }
            public List<Tinh>? tinh { get; set; }
            public List<Gia>? gia { get; set; }
            public List<ChucDanh>? chucdanh { get; set; }
            public List<Loai>? loai { get; set; }
            public List<NgoaiNgu>? ngoaingu { get; set; }
            public List<Nganh>? nganh { get; set; }
        }
        public class YeuCauKyNang {
            public string? tengoi { get; set; }
            public string? url { get; set; }

        }
        public class NganhHoc {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class HeDaoTao {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class DiaChiMap
        {
            public string? tengoi { get; set; }
            public string? toadox { get; set; }
            public string? toadoy { get; set; }

        }
        public class Tinh {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class Gia
        {
            public string? sotien { get; set; }
            public string? viet { get; set; }
            public string? donvi { get; set; }
        }
        public class ChucDanh
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class Loai
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class NgoaiNgu
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class Nganh
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
    }
}
