namespace ProjectTestApi.Models
{
    public class FunctionsUserModel
    {
        public List<FunctionDetail> Functions { get; set; }
        public class FunctionDetail
        {
            public string? tieude { get; set; }
            public string? url { get; set; }
            public string? module { get; set; }
            public string? tenham { get; set; }
        }
    }
}
