using System.Security.Policy;

namespace ProjectTestApi.Models
{
    public class Member1Model
    {
        public string? metatitle { get; set; }
        public string? tieude { get; set; }
        public string? url { get; set; }
        public string? module { get;set; }
        public string? tenham { get; set; }
        public string? DangNhap { get; set; }
        public string? id { get; set; }
        public string? thongbao { get; set; }
        public string? tennhom { get; set; }
        public string? kieu { get; set; }
        public string? huongdan { get; set; }
        public List<GiaTriDetail>? giatri { get; set; }
        public List<NoiDungFormDetail>? noidungform { get; set; }
        public CauHinh? cauhinh { get; set; }
        public class GiaTriDetail
        {
            public string? tenkh { get; set; }
            public string? gioitinh { get; set; }
            public string? sinhnhat { get; set; }
            public string? diachi { get; set; }
            public string? diachibando { get; set; }
            public string? email { get; set; }
            public string? dienthoai { get; set; }
            public string? mobile { get; set; }
            public string? yahoo { get; set; }
            public string? skype { get; set; }
            public string? MSN { get; set; }
            public string? Facebook { get; set; }
            public string? id { get; set; }
            public string? ord { get; set; }
            public string? ghichu { get; set; }
            public string? truongdaotao { get; set; }
            public string? hedaotao { get; set; }
            public  string? nganhhoc { get; set; }
            public string? thoigian { get; set; }
            public string? tencongty { get; set; }
            public string? diachicongty { get; set; }
            public string? nguoiquanly { get; set; }
            public string? dienthoainql { get; set; }
            public string? vitricongviec { get; set; }
            public string? mucluongkhoidiem { get; set; }
            public string? mucluongketthuc { get; set; }
            public string? thanhtich { get; set; }
        }
        public class NoiDungFormDetail
        {
            public string? tennhom { get; set; }
            public string? tieude { get; set; }
            public string? huongdan { get; set; }
            public string? kieu { get; set; }
            public CauHinh? cauhinh { get; set; }
        }
        public class CauHinh
        {
            public string? id { get; set; }
            public string? tieude { get; set; }
            public string? kieu { get;set; }
            public string? nhandan { get; set; }
            public string? batbuoc { get; set; }
            public string? sua { get; set; }
            public string? huongdan { get; set; }
            public string? giatri { get; set; }
            public string? nhom { get; set; }
        }

    }
}
