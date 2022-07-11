using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : BaseHandler<Product>, IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await Repository.GetByFilterAsync(x => x.Id == request.Id);
            return Mapper.Map<ProductListDto>(data);
        }
    }
}
