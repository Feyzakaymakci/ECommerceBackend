using ECommerceBackend.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest :IRequest<GetAllProductQueryResponse>  //Mediatr sayesinde hangi sınıfın request sınıfı olduğunu ve bu request sınıfın neticesinde hangi sınıfın response olarak geriye döndüreleceğini biliyoruz.
    {
        public Pagination Pagination { get; set; }
    }
}
