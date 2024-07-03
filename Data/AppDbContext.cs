using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// Data/AppDbContext.cs
using WhatsAppSessionApi.Models;

namespace WhatsAppSessionApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<WhatsAppSession> WhatsAppSessions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
