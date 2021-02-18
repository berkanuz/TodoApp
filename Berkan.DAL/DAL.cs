using Berkan.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Berkan.Data
{
    public class DAL : DbContext
    {
        public DAL(DbContextOptions<DAL> options) : base(options) { }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
