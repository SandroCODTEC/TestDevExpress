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
            }
        }
    }
}
