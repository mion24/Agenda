using AgendaPva.Core.Contexts.SharedContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new Exception("Email invalido");

            Address = address.Trim().ToLower();

            if (Address.Length < 5)
                throw new Exception("Email invalido");

            if (!EmailRegex().IsMatch(Address))
                throw new Exception("Email invalido");
        }
            
        public string Address { get; }

        #region Funcoes

        public static implicit operator Email(string address)
            => new Email(address);        

        public static implicit operator string(Email email)
           => email.ToString();

        public override string ToString()
            => Address.Trim().ToLower();

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
        #endregion
    }
}
