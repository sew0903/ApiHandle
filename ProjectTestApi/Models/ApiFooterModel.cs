namespace ProjectTestApi.Models
{
    public class ApiFooterModel
    {
        public string? kieuhienthi { get; set; }
        public string? hinhdaidien { get; set; }
        public string? tieude { get; set; }
        public string? tomtat { get; set; }
        public List<NoiDung>? noidung { get; set; }
        public class NoiDung
        {
            public string? hinhdaidien { get; set; }
            public string? tieude { get; set; }
            public string? url { get; set; }
        }
    }
}
