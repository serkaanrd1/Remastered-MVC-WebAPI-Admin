using Microsoft.EntityFrameworkCore;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.implementations.EF.Context
{
    public class RemasteredContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(@"server=.;database=Remastered;trusted_connection=true;");

        }
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Technician>? Technicians { get; set; }
        public DbSet<ServicePerformed>? ServicesPerformed { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Issue>? Issues { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<AdminPanelUser>? AdminPanelUsers { get; set; }


    }






}

