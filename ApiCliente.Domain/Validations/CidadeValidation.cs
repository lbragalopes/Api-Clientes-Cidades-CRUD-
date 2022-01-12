using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Domain.Validations
{
    public class CidadeValidation
    
    {
        public bool ValidarNomeCidade(string nome)
        {
            if (string.IsNullOrEmpty(nome) || nome.Length > 20)
                return true;
            else
                return false;
        }
        public bool ValidarEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado) || estado.Length > 2)
                return true;
            else
                return false;
        }
    }
}
