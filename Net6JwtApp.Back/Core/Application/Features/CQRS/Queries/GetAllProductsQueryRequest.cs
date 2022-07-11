using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>>
    {
    }
}
