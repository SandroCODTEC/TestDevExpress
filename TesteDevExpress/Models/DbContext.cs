using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDevExpress.Models
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }
        public virtual DbSet<Fornecedores> Fornecedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=DevExpress;user=root;pwd=evolution;");
            }
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity("SmartView.API.Models.Fornecedores", b =>
        //        {
        //            b.Property<int>("Id")
        //                .ValueGeneratedOnAdd();

        //            b.Property<bool>("Ativo");

        //            b.Property<string>("Nome");

        //            b.HasKey("Id");

        //            b.ToTable("Fornecedores");
        //        });

        //}
    }
}
