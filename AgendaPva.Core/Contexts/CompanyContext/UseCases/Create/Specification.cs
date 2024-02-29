using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.CompanyContext.UseCases.Create
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request)
            => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.name, 160, "Name", "O nome da empresa deve ter menos que 160 caracteres")
            .IsGreaterThan(request.name, 3, "Name", "O nome da empresa deve ter ao menos 3 caracteres")
            .IsLowerThan(request.Cnpj, 18, "CNPJ", "O Cnpj deve ter menos de 18 caracteres")
            .IsGreaterOrEqualsThan(request.Cnpj, 14, "CNPJ", "O Cnpj deve ter ao menos 14 caracteres")
            ;
    }
}
