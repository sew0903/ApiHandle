using System.Text.RegularExpressions;

namespace ProjectTestApi.Models
{
    public class ApiNewDetailModel
    {
        public string? id { get; set; }
        public string? ngaydang { get; set; }
        public string? luotxem { get; set; }
        public string? tieude { get; set; }
        public string? noidungtomtat { get; set; }
        public string? noidungchitiet { get; set; }
        public bool? chophepbinhluan { get; set; }
        public bool? hienthibinhluan { get; set; }
        public string? videocode { get; set; }
        public ApiNewDetailModel()
        {
            this.chophepbinhluan = true;
            this.hienthibinhluan = true;
        }
        public static string GetVideoId(string youtubeUrl)
        {
            string pattern = @"^(?:(?:https?:)?\/\/)?(?:www\.)?(?:youtube\.com|youtu\.be)\/(?:watch\?v=|embed\/|v\/|youtu\.be\/|user\/\S+\/|playlist\?list=\S+)([\w-]+)";
            Match match = Regex.Match(youtubeUrl, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
    }
}
