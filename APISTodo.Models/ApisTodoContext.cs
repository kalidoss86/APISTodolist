using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;

namespace ApisTodo.Models
{
    public class ApisTodoEntityCore : DbContext
    {
        private DbContextOptions contextOptions;
        public ApisTodoEntityCore(DbContextOptions options) : base(options)
        {
            contextOptions = options;
        }

        public virtual DbSet<TodoItem> TodoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
           // contextOptionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Kamurugan\Documents\Visual Studio 2017\Projects\APISTodolist\APISTodolist\App\TodoList.mdf';Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoList").HasKey(t => t.TodoId);
            //base.OnModelCreating(modelBuilder);
        }
    }
}
