using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cookie_MVC.Models;

namespace Cookie_MVC.Data
{
    public class Cookie_MVCContext : DbContext
    {
        public Cookie_MVCContext (DbContextOptions<Cookie_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Cookie_MVC.Models.Cookie> Cookie { get; set; } = default!;
    }
}
