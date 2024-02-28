using AgendaPva.Core.Contexts.AccountContext.Entities;
using AgendaPva.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using AgendaPva.Core.Contexts.AccountContext.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AgendaPva.Core.Contexts.AccountContext.UseCases.Response;

namespace AgendaPva.Core.Contexts.AccountContext.UseCases
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;

        public Handler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            #region Validar a requisição
            try
            {
                var res = Specification.Ensure(request);

                if (!res.IsValid)
                {
                    return new Response("Requisição inválida", 400, res.Notifications);
                }
            }
            catch
            {
                return new Response("Requisição não processada", 500);
            }
            #endregion

            #region Gerar Objetos

            Email email;
            Password password;
            User user;

            try
            {
                email = new(request.Email);
                password = new(request.Password);
                user = new(request.Name, email, password);
            }
            catch
            {
                return new Response("Requisição não processada", 500); //entra nas validações e retorna as notifications 
            }
            #endregion

            #region Validar se o email já existe no banco
            try
            {
                var exists = await _repository.AnyAsync(request.Email, cancellationToken);

                if (exists)
                    return new Response("Este E-mail já está em uso", 400);

            }
            catch 
            {
                return new Response("Falha ao verificar email cadastrado", 500);
            }
            #endregion

            #region Insere no banco
            try
            {
                await _repository.SaveAsync(user, cancellationToken);
            }
            catch (Exception)
            {
                return new Response("Falha ao persistir dados", 500);
            }

            #endregion

            return new Response("Conta criada com sucesso", new ResponseData(user.Id, user.Name, user.Email));
        }
    }
}
