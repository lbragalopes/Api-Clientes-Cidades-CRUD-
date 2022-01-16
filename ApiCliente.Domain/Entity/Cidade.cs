using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Domain.Entity
{
    public class Cidade : Base
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(20, ErrorMessage = "O Campo logradouro deve conter no máximo 20 caracteres")]
        public string Nome { get; set; }
        [StringLength(2, ErrorMessage = "O Campo estado deve conter no máximo 2 caracteres")]
        public string Estado { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}