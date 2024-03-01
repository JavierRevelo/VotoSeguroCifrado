using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VotoSeguro.Models;

namespace VotoSeguro.Data
{
    public class VotoSeguroContext : DbContext
    {
        public VotoSeguroContext (DbContextOptions<VotoSeguroContext> options)
            : base(options)
        {
        }

        public DbSet<VotoSeguro.Models.VotesRecord> VotesRecord { get; set; } = default!;
    }
}
