﻿using MediatR;

namespace Net6JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string? Definition { get; set; }
    }
}
