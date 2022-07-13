using AutoMapper;
using MediatR;
using Net6JwtApp.Back.Core.Application.Dtos;
using Net6JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Net6JwtApp.Back.Core.Application.Interfaces;
using Net6JwtApp.Back.Core.Domain;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryRequestHandler : BaseHandler<AppUser, AppRole>, IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        public CheckUserQueryRequestHandler(IRepository<AppUser> repository, IRepository<AppRole> txRepository, IMapper mapper) : base(repository, txRepository, mapper)
        {
        }
        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await TRepository.GetByFilterAsync(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Username = user.Username;
                dto.Id = user.Id;
                dto.IsExist = true;
                dto.Role = (await TXRepository.GetByFilterAsync(r => r.Id == user.AppRoleId))?.Definition;
            }
            return dto;
        }
    }
}
