using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PraticalTest.Models
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="Favor informe o usuário!")]
        [Display (Name="Usuário: ")]
        public String Usuario { get; set; }

        [Required(ErrorMessage = "Favor informe a senha!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha: ")]
        public String Senha { get; set; }

        
        [Display(Name = "Lembrar me")]
        public bool LembrarMe { get; set; }
    }
}