using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FamBridgeApi.Models;

namespace FamBridgeApi.Models
{
    public class FamBridgeContext : DbContext
    {
        public FamBridgeContext(DbContextOptions<FamBridgeContext> options)
            : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<FamBridgeApi.Models.CaseToken> CaseToken { get; set; }
    }

}
