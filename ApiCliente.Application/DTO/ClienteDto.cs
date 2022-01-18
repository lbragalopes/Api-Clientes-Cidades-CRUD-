using System;

namespace ApiCliente.Application.DTO
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
    }
}
