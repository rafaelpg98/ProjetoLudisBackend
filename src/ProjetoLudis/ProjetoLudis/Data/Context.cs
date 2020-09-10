using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoLudis.Models;

namespace ProjetoLudis.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { } 
        public DbSet<Usuario> Usuarios { get; set; }
       // public DbSet<IdentityUser> Usuario { get; set; }
        public DbSet<Esportista> Esportistas { get; set; }
        public DbSet<Comerciante> Comerciantes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Comerciante>()
                .HasData(new List<Comerciante>{
                    new Comerciante(1, "Clube do 100", "1222521/0001-01", 1)
                });

            builder.Entity<Esportista>()
                .HasData(new List<Esportista>{
                    new Esportista(1, "13131308670"),
                });

            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario(1,  "Iury@teste.com.br", "iury123", "Iury", "997288193", "37190000", "Três Pontas", "R. José Caixambu Nº 213", "Centro", "UF",1,0),
                    new Usuario(2,  "           ", "iury123", "Iury", "997288193", "37190000", "Três Pontas", "R. José Caixambu Nº 213", "Centro", "UF",0,1)
                });

        }
    }
}