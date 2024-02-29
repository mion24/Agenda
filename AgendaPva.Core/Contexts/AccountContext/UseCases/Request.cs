using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.AccountContext.UseCases
{
    public record Request(string Name, string Email, string Password) : IRequest<Response>;
}
