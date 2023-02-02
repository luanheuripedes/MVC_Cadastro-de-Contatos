using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ContatoDTO
    {
        public int Id { get; set; }


        public string Nome { get; set; }


        public string Email { get; set; }


        public string Celular { get; set; }
        public int? UsuarioId { get; set; }
    }
}
