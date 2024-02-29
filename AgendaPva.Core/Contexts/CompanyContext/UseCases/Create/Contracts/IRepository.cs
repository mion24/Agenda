using AgendaPva.Core.Contexts.AccountContext.Entities;
using AgendaPva.Core.Contexts.CompanyContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.CompanyContext.UseCases.Create.Contracts
{
    public interface IRepository
    {
        Task<bool> AnyAsync(string Cnpj, CancellationToken cancellationToken);
        Task SaveAsync(Company company, CancellationToken cancellationToken);
    }
}
