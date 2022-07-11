using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoriesQueryHandler : BaseHandler<Category>, IRequestHandler<GetAllCategoriesQueryRequest, List<CategoryDto>>
    {
        public GetAllCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await Repository.GetAllAsync();
            return Mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
