using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Enums;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : BaseHandler<AppUser>, IRequestHandler<RegisterUserCommandRequest>
    {
        public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await Repository.CreateAsync(new AppUser()
            {
                AppRoleId = (int)RoleType.Member,
                Username = request.Username,
                Password = request.Password
            });
            return Unit.Value;
        }
    }
}
