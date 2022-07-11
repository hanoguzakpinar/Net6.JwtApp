using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : BaseHandler<Product>, IRequestHandler<UpdateProductCommandRequest>
    {
        public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var oldEntity = await Repository.GetByIdAsync(request.Id);
            if (oldEntity != null)
            {
                oldEntity.CategoryId = request.CategoryId;
                oldEntity.Name = request.Name;
                oldEntity.Price = request.Price;
                oldEntity.Stock = request.Stock;
                await Repository.UpdateAsync(oldEntity);
            }
            return Unit.Value;
        }
    }
}
