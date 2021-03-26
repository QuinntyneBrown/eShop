using MediatR;
using System;

namespace eShop.Api.Core
{
    public class DomainEvent: INotification
    {
        public DateTime Created { get; private set; } = DateTime.UtcNow;
    }
}
