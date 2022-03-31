using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
