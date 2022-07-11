using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : BaseHandler<Product>, IRequestHandler<CreateProductCommandRequest>
    {
        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await Repository.CreateAsync(new Product()
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
            return Unit.Value;
        }
    }
}
