using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SkillTestASP.Models;

public partial class Database2Context : DbContext
{
    public Database2Context()
    {
    }

    public Database2Context(DbContextOptions<Database2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee2> Employee2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;database=Database2;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee2");

            entity.Property(e => e.Employee).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
