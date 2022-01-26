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
        
        public string Email { get; set; }
        
        public string Pass { get; set; }
    }
}
