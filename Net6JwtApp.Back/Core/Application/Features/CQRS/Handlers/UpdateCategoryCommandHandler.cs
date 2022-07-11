using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : BaseHandler<Category>, IRequestHandler<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var oldCategory = await Repository.GetByIdAsync(request.Id);
            if (oldCategory is not null)
            {
                oldCategory.Definition = request.Definition;
                await Repository.UpdateAsync(oldCategory);
            }
            return Unit.Value;
        }
    }
}
