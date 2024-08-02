using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Messages
{
    public class UserHasBeenSignedUpMessage : INotification
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
