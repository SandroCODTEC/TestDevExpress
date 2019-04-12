using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeAspNetCoreApp1.Models
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Order Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=177.12.174.20;database=codtec10;user=codtec12;pwd={password};");
            }
        }
    }
}
