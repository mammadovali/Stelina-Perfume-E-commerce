using Stelina.Domain.AppCode.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.AppCode.Services
{
    public class CryptyoService // optionlari ishledir
    {
        private readonly CryptyoServiceOptions options;

        public CryptyoService(IOptions<CryptyoServiceOptions>  options) //constructor optionlari qebul edir
        {
            this.options = options.Value; 
        }

        public string Encrypt(string value, bool appliedUrlEncode = false)
        {
            return value.Encrypt(options.SymmetricKey, appliedUrlEncode);
        }

        public string Decrypt(string value)
        {
            return value.Decrypt(options.SymmetricKey);
        }
    }

    public class CryptyoServiceOptions
    {
        public string SaltKey { get; set; }

        public string SymmetricKey { get; set; }
    }
}
