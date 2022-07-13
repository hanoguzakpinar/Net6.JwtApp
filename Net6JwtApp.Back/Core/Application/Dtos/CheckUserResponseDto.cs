﻿namespace Net6JwtApp.Back.Core.Application.Dtos
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsExist { get; set; }
    }
}
