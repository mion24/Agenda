using AgendaPva.Core.Contexts.AccountContext.Entities;
using AgendaPva.Core.Contexts.CompanyContext.ValueObjects;
using AgendaPva.Core.Contexts.SharedContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.CompanyContext.Entities
{
    public class Company : Entity
    {
        public Company(Cnpj cnpj, string name,string[] phoneNumbers, string image, Guid companyOwnerId, bool isSub = false)
        {
            Cnpj = cnpj;
            Name = name;
            PhoneNumbers = phoneNumbers;
            Image = image;
            IsSub = isSub;
        }

        protected Company()
        { }

        public Cnpj Cnpj { get; private set; }
        public string Name { get; set; }
        public string[] PhoneNumbers { get; private set; } 
        public string Image { get; private set; }
        public bool IsSub { get; private set; }
        public Guid CompanyOwner { get; private set; }
    }
}
