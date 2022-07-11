using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest : IRequest<ProductListDto>
    {
        public GetProductQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
