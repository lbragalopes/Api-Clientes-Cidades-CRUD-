using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCliente.Domain.Entity
{
    public class Cidade
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string Nome { get; set; }
        [StringLength(2, ErrorMessage = "O Campo estado deve conter no máximo 2 caracteres")]
        public string Estado { get; set; }
        [JsonIgnore]
        public ICollection<Cliente> Clientes { get; set; }
    }
}