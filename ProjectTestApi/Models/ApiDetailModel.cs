using static ProjectTestApi.Models.ApiCartModel;
using static ProjectTestApi.Models.ApiModel;

namespace ProjectTestApi.Models
{
    public class ApiDetailModel
    {
        public string? id { get; set; }
        public string? url { get; set; }
        public string? tieude { get; set; }
        public string? loaitin { get; set; }
        public string? matin { get; set; }
        public string? mota { get; set; }
        public  string? tenND { get; set; }
        public  string? diachiND { get; set; }
        public  string? dienthoaiND { get; set; }
        public  string? dienthoaixxxND { get; set; }
        public  string? emailND { get; set; }
        public  string? emailxxxND { get; set; }
        public  string? ngaydang { get; set; }
        public  string? luotxem { get; set; }
        public  bool? chophepbinhluan { get; set; }
        public  bool? hienthibinhluan { get; set; }
        public List<Nganh>? nganh { get; set; }
        public List<YeuCauKyNang>? yeucaukynang { get; set; }
        public List<TruongDaoTao>? truongdaotao { get; set; }
        public List<NganhHoc>? nganhhoc { get; set; }
        public List<HeDaoTao>? hedaotao { get; set; }
        public List<NgoaiNgu>? ngoaingu { get; set; }
        public List<DiaChiMap>? diachimap { get; set; }
        public List<Tinh>? tinh { get; set; }
        public string? thoihan { get; set; }
        public List<Gia>? gia { get; set; }
        public List<MaLoc>? maloc { get; set; }

        public class Nganh
        {
           public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class YeuCauKyNang
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class TruongDaoTao
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
        public class NgoaiNgu
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
        public class Gia
        {
            public string? sotien { get; set; }
            public string? viet { get; set; }
            public string? donvi { get; set; }
        }
        public class MaLoc
        {
            public string? tennhom { get; set; }
            public string? giatri { get; set; }
        }
        public ApiDetailModel()
        {
            this.chophepbinhluan = false;
            this.hienthibinhluan = false;
        }
    }
}
