﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.Commands.SubscribeUser
{
    public class SubscribeUserCommand : IRequest
    {
        public string Type { get; set; }
    }
}
