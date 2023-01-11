using Stelina.Domain.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewModels.LoginRegister
{
    public class LoginRegisterViewModel
    {
        public LoginFormModel LoginForm { get; set; }

        public RegisterFormModel RegisterForm { get; set; }
    }
}
