using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : BaseHandler<Product>, IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await Repository.GetAllAsync();
            return Mapper.Map<List<ProductListDto>>(data);
        }
    }
}
