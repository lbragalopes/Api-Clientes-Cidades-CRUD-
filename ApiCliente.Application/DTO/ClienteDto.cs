using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Application.DTO
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Cep { get; set; }


    }
}
