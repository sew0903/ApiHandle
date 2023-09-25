namespace ProjectTestApi.Models
{
    public class ApiModel
    {
        public string? id { get; set; }
        public string? ngaydang { get; set; }
        public string? hinhdaidien { get; set; }
        public string? tieude { get; set; }
        public string? url { get; set; }
        public string? noidungtomtat { get; set; }

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
        public List<ChucDanhDetail>? chucdanh { get; set; }
        public List<NganhDetail>? nganh { get; set; }
        public List<DiaChiMapDetail>? diachimap { get; set; }
        public List<TinhDetail>? tinh { get; set; }
        public List<GiaDetail>? gia { get; set; }
        public List<LoaiDetai>? loai { get; set; }

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
        public class NgoaiNguDetail
        {
            public string? tengoi { get; set; }
            public string? url { get; set; }
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
            public List<LoaiDetai>? loai { get; set; }
            public List<ChucDanhDetail>? chucdanh { get; set; }
            public List<NganhDetai>? nganh { get; set; }
            public List<NgoaiNguDetail>? ngoaingu { get; set; }
            public List<DiaChiMapDetail>? diachimap { get; set; }
            public List<TinhDetai>? tinh { get; set; }
            public List<GiaDetail>? gia { get; set; }
        }

    }
}
