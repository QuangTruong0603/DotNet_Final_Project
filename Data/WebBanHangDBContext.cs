using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using do_an_ck.Models;

    public class WebBanHangDBContext : DbContext
    {
        public WebBanHangDBContext (DbContextOptions<WebBanHangDBContext> options)
            : base(options)
        {
        }

        public DbSet<do_an_ck.Models.Role> Role { get; set; } = default!;

        public DbSet<do_an_ck.Models.User>? User { get; set; }
    }
