using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class RedefinirSenhaDTO
    {
        public string Email { get; set; }
        public string Login { get; set; }
    }
}
