using System.ComponentModel.DataAnnotations;

namespace ProjectTestApi.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
