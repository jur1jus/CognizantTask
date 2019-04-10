using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dal.Models;

namespace Dal
{
    public class CognizantDataContext : DbContext
    {
		public CognizantDataContext(DbContextOptions options)
			:base(options)
		{

		}

		public DbSet<Task> Tasks { get; set; }

		public DbSet<TestCase> TestCases { get; set; }

		public DbSet<UserSubmission> UsersSubmissions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var tasksCfg = modelBuilder.Entity<Task>();
			tasksCfg.ToTable("Tasks");
			tasksCfg.HasKey(m => m.Id);
			tasksCfg.Property(m => m.Id).HasColumnName("Id").ValueGeneratedOnAdd();


			var testCasesCfg = modelBuilder.Entity<TestCase>();
			testCasesCfg.ToTable("TestCases");
			testCasesCfg.HasKey(m => m.Id);
			testCasesCfg.Property(m => m.Id).HasColumnName("Id").ValueGeneratedOnAdd();
			testCasesCfg.Property(m => m.TaskId).HasColumnName("TaskId");

			var usersSubmissionsCfg = modelBuilder.Entity<UserSubmission>();
			usersSubmissionsCfg.ToTable("UserSubmissions");
			usersSubmissionsCfg.HasKey(m => m.Id);
			usersSubmissionsCfg.Property(m => m.Id).HasColumnName("Id").ValueGeneratedOnAdd();
		}
	}
}
