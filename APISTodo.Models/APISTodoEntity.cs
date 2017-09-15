using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApisTodo.Models
{
    public class ApisTodoEntity : IdentityDbContext<IdentityUser>
    {
        public ApisTodoEntity(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>().HasKey(t => t.TodoId);
            base.OnModelCreating(builder);
        }

        public virtual DbSet<TodoItem> TodoItems { get; set; }
    }
}
