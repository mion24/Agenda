using SecureIdentity.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.AccountContext.ValueObjects
{
    public class Password
    {
        protected Password()
        { }

        public Password(string plainPassword)
        {
            Hash = PasswordGenerator.Generate();
        }

        public string Hash { get; } = string.Empty;
    }
}
