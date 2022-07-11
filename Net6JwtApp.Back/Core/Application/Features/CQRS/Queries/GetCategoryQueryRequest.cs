using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryDto>
    {
        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
