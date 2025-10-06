﻿using Cwk.Domain.Enums;

namespace Cwk.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string? PhoneNumber { get; set; }
        public Role Role { get; set; }
    }
}