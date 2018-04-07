using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="E-mail Invalid!")]
        [Display (Name="E-mail: ")]
        public String Usuario { get; set; }

        [Required(ErrorMessage = "Password Invalid!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public String Senha { get; set; }

        
        [Display(Name = "Lembrar me")]
        public bool LembrarMe { get; set; }
    }
}