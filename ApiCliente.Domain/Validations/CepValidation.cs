using ApiCliente.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Domain.Validations
{
    public class CepValidation : AbstractValidator<Cliente>
    {

     public CepValidation()
            {
                RuleFor(viaCep => viaCep.Cep).NotEmpty().WithMessage("Por favor, preencha o CEP.");
                RuleFor(viaCep => viaCep.Cep).Matches(@"^[0-9]{5}-?[0-9]{3}$").WithMessage("O CEP informado é inválido.");
            }

        }
    }