using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dal.ViewModels;

namespace Dal
{
    public class CognizantDataContext : DbContext
    {
		public CognizantDataContext(DbContextOptions options)
			:base(options)
		{

		}

		public DbSet<Task> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var tasksCfg = modelBuilder.Entity<Task>();
			tasksCfg.ToTable("Tasks");
			tasksCfg.HasKey(m => m.Id);
			tasksCfg.Property(m => m.Id).HasColumnName("Id").ValueGeneratedOnAdd();
			tasksCfg.Property(m => m.Name).HasColumnName("Name").HasMaxLength(100);

			
		}
	}
}
