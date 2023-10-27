namespace ProjectTestApi.Models
{
    public class ApiCartModel
    {
        public string? recordsTotal { get; set; }
        public string? recordsFiltered { get; set;}
        public List<DataDetail>? data { get; set; }
        public class DataDetail
        {
            public string? thoigian { get; set; }
            public string? soluong { get; set; }
            public string? gia { get; set; }
            public string? tinhtrang { get; set; }
            public string? id { get; set; }
            public string? loaitin { get; set; }
            public string? url { get; set; }
            public string? tieude { get; set; }
            public List<KyNang>? yeucaukynang { get; set; }
            public List<NgoaiNgu>? ngoaingu { get; set; }
            public List<NganhHoc>? nganhhoc { get; set; }
            public List<HeDaoTao>? hedaotao { get; set; }
            public List<DiaChiMap>? diachimap { get; set; }
            public List<Tinh>? tinh { get; set; }
            public string? tenND { get; set; }
            public string? diachiND { get; set; }
            public string? emailND { get; set; }
            public string? emailxxxND { get; set; }
        }
        public class KyNang
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
            public string? tengoi
            {
                get; set;
            }
            public string? url
            {
                get; set;
            }
        } 
        public class DiaChiMap
        {
            public string? tengoi
            {
                get; set;
            }
            public string? toadox { get; set; }
            public string? toadoy { get; set; }
        } 
        public class Tinh
        {
            public string? tengoi
            {
                get; set;
            }
            public string? url
            {
                get; set;
            }
        } 
        public class NgoaiNgu
        {
            public string? tengoi
            {
                get; set;
            }
            public string? url
            {
                get; set;
            }
        } 

    }
}
