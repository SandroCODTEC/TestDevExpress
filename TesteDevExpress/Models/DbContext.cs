using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDevExpress.Models
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Sale Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=DevExpress;user=root;pwd={password};");
            }
        }
    }
}
