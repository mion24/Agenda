using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.AccountContext.UseCases
{
    public class Response : SharedContext.UseCases.Response
    {
        protected Response()
        {

        }

        public Response(string message, int status, IEnumerable<Notification>? notifications = null)
        {
            Message = message;
            Status = status;                            //herdado de response sharedcontext
            Notifications = notifications;
        }

        public Response(string message, ResponseData data)
        {
            Message = message;
            Status = 201;
            Notifications = null;
            Data = data;
        }

        public ResponseData? Data { get; set; }
        public record ResponseData(Guid id, string name, string email);

    }
}
