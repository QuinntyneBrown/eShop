using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Testing.Builders
{
    using static eShop.Api.Features.CheckoutOrder;
    public class CheckoutOrderBuilder
    {
        public class RequestBuilder
        {
            private Guid _orderId;

            public RequestBuilder WithOrderId(Guid orderId)
            {
                _orderId = orderId;
                return this;
            }

            public Request Build()
            {
                return new Request
                {

                };
            }
        }
    }
}
