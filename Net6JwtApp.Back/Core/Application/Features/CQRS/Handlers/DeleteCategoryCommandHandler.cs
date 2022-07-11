using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : BaseHandler<Category>, IRequestHandler<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandHandler(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await Repository.GetByIdAsync(request.Id);
            if (category != null) await Repository.RemoveAsync(category);
            return Unit.Value;
        }
    }
}
