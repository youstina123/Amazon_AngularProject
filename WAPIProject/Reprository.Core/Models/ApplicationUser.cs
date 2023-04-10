﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Reprository.Core.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class ApplicationUser:IdentityUser
    {
        public string? PhoneNumber { get; set; }
        public Gender? gender { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public byte[]? image { get; set; }
        public bool IsDeleted { get; set; }

    }
}
