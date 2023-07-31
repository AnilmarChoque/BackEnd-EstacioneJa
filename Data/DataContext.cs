using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstacioneJa.Models;

namespace EstacioneJa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Gerente> Gerentes { get; set;}
        public DbSet<OcupacaoVaga> OcupacaoVagas { get; set;}
        public DbSet<Pagamento> Pagamentos { get; set;}
        public DbSet<Sensor> Sensores { get; set;}
        public DbSet<Usuario> Usuarios{ get; set;}
        public DbSet<Vaga> Vagas { get; set;}
    }
}