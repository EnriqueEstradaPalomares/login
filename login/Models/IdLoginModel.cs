using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace login.Models
{
    public class IdLoginModel
    {
        [Key]
        public int Id { get; set; }
    }
}
