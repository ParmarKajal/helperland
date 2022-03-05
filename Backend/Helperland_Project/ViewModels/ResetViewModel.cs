using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.ViewModels
{
    public class ResetViewModel
    {
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
       

        [Required]
        [StringLength(100)]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(100)]
        public string ConfirmPassword { get; set; }

        public string ResetCode { get; set; }


    }
}
