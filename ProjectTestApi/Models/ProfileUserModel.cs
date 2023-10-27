namespace ProjectTestApi.Models
{
    public class ProfileUserModel
    {
        public string? ThongBao { get; set; }   
        public string? maloi { get; set; }
        public string? memberid { get;set; }
        public string? user { get;set; }
        public string? chucnang { get; set; }  

        public List<ThongTinThanhVienDetail>? thongtinthanhvien { get; set; }
        public List<BoLocThanhVienDetail>? bolocthanhvien { get; set; }

        public class ThongTinThanhVienDetail
        {
            public string? tennhom { get; set; }
            public CauHinhDetail? cauhinh { get; set; }
        }
        public class BoLocThanhVienDetail
        {
            public string? tennhom { get; set; }
            public CauHinhDetail? cauhinh { get; set; }
        }
        public class CauHinhDetail
        {
            public string? id { get; set; }
            public string? tieude { get; set; } 
            public string? kieu { get; set; }
            public string? nhandan { get; set; }
            public string? batbuoc { get; set; }
            public string? sua { get; set; }
            public string? huongdan { get; set; }
            public string? giatri { get; set; }
            public string? nhom { get; set; }
            public string? loai { get; set; }
        }
    }
}
