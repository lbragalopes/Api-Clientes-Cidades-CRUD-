using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Domain.Entity
{
    public class Cliente 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(30, ErrorMessage = "Campo nome deve conter no máximo 30 caracteres")]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }

    }
}

