using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace login.Models
{
    [Keyless]
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}
