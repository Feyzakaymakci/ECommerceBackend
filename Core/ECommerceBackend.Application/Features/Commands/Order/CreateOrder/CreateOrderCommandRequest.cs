using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest:IRequest<CreateOrderCommandResponse>
    {
    }
}
