using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_Project.ViewModels
{
    public class ContactUsViewModel
    {
        [Required]
        [StringLength(50)]
        public string firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string lastname { get; set; }
        [Required]
        [StringLength(200)]
        public string email { get; set; }
        [StringLength(500)]
        public string subject { get; set; }
        [Required]
        [StringLength(20)]
        public string mobile { get; set; }
        [Required]
        [StringLength(200)]
        public string message { get; set; }
        public IFormFile uploadFileName { get; set; }
       
    }
}
