namespace ProjectTestApi.Models
{
    public class ApiCommentModel
    {
        public string? recordTotal { get; set; }
        public string? recordsFiltered { get;set; }
        public List<Data>? data { get; set; }
        public class Data
        {
            public string? id { get; set; }
            public string? idquanly { get; set; }
            public string? ngaydang { get; set; }
            public string? hinhdaidien { get; set; }
            public string? nguoidung { get; set; }
            public string? noidungbinhluan { get; set; }
        }
    }
}
