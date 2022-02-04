using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        [StringLength(100)]
        public string firstname { get; set; }
        [Required]
        [StringLength(100)]
        public string lastname { get; set; }
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        
        //[DataType(DataType.Password)]
        [Required]
        [Compare("Password" , ErrorMessage = "Password and Confirm Password must be match!")]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(20)]
        public string mobile { get; set; }

        public bool RememberMe { get; set; }
        public int UserTypeId { get; set; }
    }
}
