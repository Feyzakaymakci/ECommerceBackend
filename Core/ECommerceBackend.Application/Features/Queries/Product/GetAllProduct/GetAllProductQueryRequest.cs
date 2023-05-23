using ECommerceBackend.Application.Features.Queries.Product.GetAllProduct;
using ECommerceBackend.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest :IRequest<GetAllProductQueryResponse>  //Mediatr sayesinde hangi sınıfın request sınıfı olduğunu ve bu request sınıfın neticesinde hangi sınıfın response olarak geriye döndüreleceğini biliyoruz.
    {
        //public Pagination Pagination { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
