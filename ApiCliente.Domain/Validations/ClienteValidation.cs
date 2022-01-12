using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Domain.Validations
{
    public class ClienteValidation
    {
        public bool ValidaNome(string nome)
        {
            if (string.IsNullOrEmpty(nome) || nome.Length > 30)
                return true;
            else
                return false;
        }
    }
}