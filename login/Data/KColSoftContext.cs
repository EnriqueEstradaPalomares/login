using login.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace login.Data
{
    public class KColSoftContext : DbContext
    {
        public KColSoftContext(DbContextOptions<KColSoftContext> options) : base(options)
        {

        }
        public DbSet<KColSoftModel> KColSoftsItem { get; set; }
    }
}
