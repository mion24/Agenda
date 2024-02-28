using AgendaPva.Core.Contexts.AccountContext.UseCases;
using AgendaPva.Core.Contexts.SharedContext.UseCases;
using Azure.Core;
using MediatR;

namespace AgendaPva.Api.Extensions
{
    public static class AccountContextExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region Create
            builder.Services.AddTransient<
                AgendaPva.Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
                AgendaPva.Infra.Contexts.AccountContext.UseCases.Create.Repository
                >();
            #endregion
        }

        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region Create      

            app.MapPost("api/v1/users", async (Core.Contexts.AccountContext.UseCases.Request request, IRequestHandler<Core.Contexts.AccountContext.UseCases.Request, AgendaPva.Core.Contexts.AccountContext.UseCases.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());

                return result.IsSuccess
                    ? Results.Created($"api/v1/users/{result.Data?.id}", result)
                    : Results.Json(result, statusCode: result.Status);
            });

            #endregion
        }
    }
}

