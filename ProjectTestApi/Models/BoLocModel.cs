using Newtonsoft.Json;
using ProjectTestApi.Models.Const;
using System.Net;

namespace ProjectTestApi.Models
{
    public class BoLocModel
    {
        public string? id { get; set; }
        public string? url { get; set; }
        public string? ten { get; set; }
        public string? ma { get; set; }
        public List<NoiDungForm>? noidungform {  get; set; }
        public List<ThamSo>? thamso { get; set; }
        public class NoiDungForm
        {
            public string? id { get; set; }
            public string? idquanly { get; set; }
            public string? danhmuc { get; set; }
            public string? idxuly { get; set; }
            public string? tieude { get; set; }
            public string? chonnhieu { get; set; }
            public string? url { get; set; }
            //public GiaTriDetail giatri { get; set;}
            public string? tennhom { get; set; }
            public string? nhom { get; set; }
        }
        public class ThamSo
        {
            public string? tengoi { get; set; }
            public string? ma { get; set; }
            public string? url { get; set; }

        }
        public string GetStringAddress(string? idState, string? idDistrict, string? idWard)
        {
            string result = "";
            string apiState = MyConstanst.SiteName+"dialy.tinhthanh.asp";
            string jsonContent = (new WebClient()).DownloadString(apiState);
            if (!string.IsNullOrEmpty(jsonContent))
            {
                List<AddressModel> states = JsonConvert.DeserializeObject<List<AddressModel>>(jsonContent);
                AddressModel state = states.FirstOrDefault(x => x.id == idState);
                if (state != null)
                {
                    result += state.ten;
                    string apiDistrict = MyConstanst.SiteName+"dialy.quanhuyen.asp?id=" + state.id;
                    jsonContent = (new WebClient()).DownloadString(apiDistrict);
                    if (!string.IsNullOrEmpty(jsonContent))
                    {
                        List<AddressModel> districts = JsonConvert.DeserializeObject<List<AddressModel>>(jsonContent);
                        AddressModel district = districts.FirstOrDefault(x => x.id == idDistrict);
                        if (district != null)
                        {
                            result += "," + district.ten;
                            string apiWards = MyConstanst.SiteName + "dialy.phuongxa.asp?id=" + district.id;
                            jsonContent = (new WebClient()).DownloadString(apiWards);
                            if (!string.IsNullOrEmpty(jsonContent))
                            {
                                List<AddressModel> wards = JsonConvert.DeserializeObject<List<AddressModel>>(jsonContent);
                                AddressModel ward = wards.FirstOrDefault(x => x.id == idWard);
                                if (ward != null)
                                {
                                    result += "," + ward.ten;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        public List<ThamSo> GetCareers(string? id)
        {
            List<ThamSo> result = new List<ThamSo>();
            string apiBoLoc = MyConstanst.SiteName+"crm.boloc.chitiet.asp?id="+id;
            string jsonContent = (new WebClient()).DownloadString(apiBoLoc);
            if(!string.IsNullOrEmpty(jsonContent)) { 
                List<BoLocModel> boLocModels = JsonConvert
                    .DeserializeObject<List<BoLocModel>>(jsonContent);
                result = boLocModels[0].thamso;
                return result;
            }
            return null;
        }
        public string FilterCareer(List<ThamSo>? thamso, string? strId)
        {
            string result = null;
            string[] arrId = strId.Split(',');
            foreach(var id in arrId)
            {
                foreach (var item in thamso)
                {
                    if(id == item.ma)
                    {
                        if(result != null)
                        {
                            result += "," + item.tengoi;
                            break;
                        }
                        else
                        {
                            result += item.tengoi;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
