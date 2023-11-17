using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManuEquiTI.Models;

namespace ManuEquiTI.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<ManuEquiTI.Models.CadClientes> CadClientes { get; set; } = default!;

        public DbSet<ManuEquiTI.Models.CadProdutos> CadProdutos { get; set; } = default!;

        public DbSet<ManuEquiTI.Models.InvtMaq> InvtMaq { get; set; } = default!;

        public DbSet<ManuEquiTI.Models.InvtSoft> InvtSoft { get; set; } = default!;
    }
}
