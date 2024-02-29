using AgendaPva.Core.Contexts.AccountContext.ValueObjects;
using AgendaPva.Core.Contexts.SharedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.AccountContext.Entities
{
    public class User : Entity
    {
        protected User() 
        { }

        public User(string name, string email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public string Name { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public Password Password { get; set; } = null!; 
    }
}
