using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCliente.Domain.Entity
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Cep { get; set; }
        public int CidadeId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        [JsonIgnore]
        public Cidade Cidade { get; set; }

    }
}

