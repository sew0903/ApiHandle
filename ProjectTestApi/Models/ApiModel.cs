namespace ProjectTestApi.Models
{
    public class ApiModel
    {
        public string? id { get; set; }
        public string? idxuly { get; set; }
        public string? ngaydang { get; set; }
        public string? hinhdaidien { get; set; }
        public string? tieude { get; set; }
        public string? url { get; set; }
        public string? noidungtomtat { get; set; }
        public string? ten { get;set; }
        public string? idpart { get; set; }
        public string? idquanly { get; set; }
        public string? kieuhienthi { get; set; }
        public string? module { get; set; }
        public string? tomtat { get; set; }
        public string? tenham { get; set; }
        public string? tenND { get; set; }
        public string? diachiND { get; set; }
        public string? emailND { get; set; }
        public string? emailxxxND { get; set; }
        public string? thoihan { get; set; }
        public int? recordsTotal { get; set; }
        public int? recordsFiltered { get; set; }

        public List<DataDetail>? data { get;set; }
        public List<NoiDungFormDetail>? noidungform { get;set; } 
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
            public string? xa { get; set; }
            public string? url { get; set; }
        }
        public class GiaDetail
        {
            public string? sotien { get; set; }
            public string? viet { get; set; }
            public string? donvi { get; set; }
        }
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
            public string? xa { get; set; }
            public string? url { get; set; }
        }
        public class NgoaiNguDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class GiaTriDetail
        {
             
        }
        public class DataDetail
        {
            public string? id { get; set; }
            public string? loaitin { get; set; }
            public string? url { get; set; }
            public string? tieude { get; set; }
            public string? name { get; set; }
            public string? thoihan { get; set; }
            public string? tenND { get; set; }
            public string? diachiND { get; set; }
            public string? emailND { get; set; }
            public string? emailxxxND { get; set; }
            public string? ngaydang { get; set; }
            public string? hinhdaidien { get; set; }
            public string? noidungtomtat { get; set; }
            public string? luotxem { get; set; } 
            public List<LoaiDetai>? loai { get; set; }
            public List<ChucDanhDetail>? chucdanh { get; set; }
            public List<NganhDetai>? nganh { get; set; }
            public List<NgoaiNguDetail>? ngoaingu { get; set; }
            public List<DiaChiMapDetail>? diachimap { get; set; }
            public List<TinhDetai>? tinh { get; set; }
            public List<GiaDetail>? gia { get; set; }
            public List<MaLocDetail>? maloc { get; set; }
            public List<DaoTaoDetail>? daotao { get; set; }
            public List<KinhNghiemDetail>? kinhnghiem { get; set; } 
            public List<ThuViecDetail>? thuviec { get; set; }
            public List<PhucLoiDetail>? phucloi { get; set; } 
        }
        public class PhucLoiDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class ThuViecDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class KinhNghiemDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class DaoTaoDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
        }
        public class MaLocDetail
        {
            public string? tennhom { get; set; }
            public string? giatri { get; set; }
        }
        public class ThamSoDetail
        {
            public string? tengoi { get; set; }
            public string? ma { get; set; }
            public string? url { get; set; }
        }
        public class NoiDungFormDetail
        {
            public string? id { get; set; }
            public string? idquanly { get; set; }
            public string? danhmuc { get; set; }
            public string? idxuly { get; set; }
            public string? tieude { get; set; }
            public string? chonnhieu { get; set; }
            public string? url { get; set;}
            //public GiaTriDetail giatri { get; set;}
            public string? tennhom { get;set; }
            public string? nhom { get; set; }
        }
        public class BoLoc
        {
            public string? ten { get; set; }
            public string? ma { get; set; }
            public List<ThamSoDetail>? thamso { get; set; }
        }

    }
}
