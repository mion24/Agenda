using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.CompanyContext.UseCases.Create
{
    public record Request(string Cnpj, string name, Guid ownerId, List<string> phones, string image) : IRequest<Response>;
}
