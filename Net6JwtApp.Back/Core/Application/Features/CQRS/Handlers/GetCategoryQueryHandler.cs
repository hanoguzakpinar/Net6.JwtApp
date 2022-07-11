using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : BaseHandler<Category>, IRequestHandler<GetCategoryQueryRequest, CategoryDto>
    {
        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<CategoryDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await Repository.GetByFilterAsync(c => c.Id == request.Id);
            return Mapper.Map<CategoryDto>(category);
        }
    }
}
