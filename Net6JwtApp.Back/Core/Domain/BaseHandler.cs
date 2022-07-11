using AutoMapper;
using Net6JwtApp.Back.Core.Application.Interfaces;

namespace Net6JwtApp.Back.Core.Domain
{
    public abstract class BaseHandler<T> where T : class, new()
    {
        public readonly IRepository<T> Repository;
        public readonly IMapper Mapper;

        protected BaseHandler(IRepository<T> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
    }
}
