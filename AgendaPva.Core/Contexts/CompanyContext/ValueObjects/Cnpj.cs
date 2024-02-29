using AgendaPva.Core.Contexts.AccountContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.CompanyContext.ValueObjects
{
    public class Cnpj
    {
        public Cnpj(string docNumber)
        {
            if (string.IsNullOrEmpty(docNumber))
            {
                throw new Exception("Cnpj invalido ou em branco");
            }

            docNumber = docNumber.Trim().ToString();   

            if (docNumber.Length < 14)
            {
                throw new Exception("Cnpj invalido");
            }

            DocNumber = docNumber;
        }

        public string DocNumber { get; set; }

        #region Funcoes
        public static implicit operator Cnpj(string docNumber)
            => new Cnpj(docNumber);

        public override string ToString()
           => DocNumber.Replace("/", "");

        #endregion
    }
}
