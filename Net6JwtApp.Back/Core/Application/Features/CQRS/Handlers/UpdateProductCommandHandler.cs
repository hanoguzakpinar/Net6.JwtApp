using MediatR;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var oldEntity = await _repository.GetByIdAsync(request.Id);
            if (oldEntity != null)
            {
                oldEntity.CategoryId = request.CategoryId;
                oldEntity.Name = request.Name;
                oldEntity.Price = request.Price;
                oldEntity.Stock = request.Stock;
                await _repository.UpdateAsync(oldEntity);
            }
            return Unit.Value;
        }
    }
}
