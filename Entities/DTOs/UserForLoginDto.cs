﻿using Core.Entity;

namespace Entities.DTOs
{
    //TODO: Genişletilecek Sınıf
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
