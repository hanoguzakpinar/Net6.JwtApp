using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : BaseHandler<Product>, IRequestHandler<DeleteProductCommandRequest>
    {
        public DeleteProductCommandHandler(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await Repository.GetByIdAsync(request.Id);
            if (entity != null) await Repository.RemoveAsync(entity);
            return Unit.Value;
        }
    }
}
