using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : BaseHandler<Category>, IRequestHandler<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await Repository.CreateAsync(new Category()
            {
                Definition = request.Definition
            });
            return Unit.Value;
        }
    }
}
