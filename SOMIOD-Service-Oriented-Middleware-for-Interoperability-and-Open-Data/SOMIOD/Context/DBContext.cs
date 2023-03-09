using SOMIOD.Models;
using System;
using System.Data.Entity;
using System.IO;

namespace SOMIOD.Context
{
    public class SomiodDBContext : DbContext
    {          
        public SomiodDBContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\SomiodDatabase.mdf") + ";Integrated Security=True")
        {
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
