using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_web
{
    public class ConectionDB : IdentityDbContext
    {
        public ConectionDB(DbContextOptions<ConectionDB> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentMatter>().HasKey(x => new { x.StudentId, x.MatterId });

            modelBuilder.Entity<IdentityUser>().ToTable("Usuarios", "Seguridad");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Seguridad");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuariosRoles", "Seguridad");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims", "Seguridad");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsuariosClaims", "Seguridad");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsuariosLogin", "Seguridad");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsuariosToken", "Seguridad");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Direction> Streets { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<StudentMatter> StudentMatters { get; set; }
        public DbSet<Matter> Matters { get; set; }
    }
}
