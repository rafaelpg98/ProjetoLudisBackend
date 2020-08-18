using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoLudis.Models;
using SmartSchool.API.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Esportista> Esportistas { get; set; }
        public DbSet<Comerciante> Comerciantes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario(1,  "Iury@teste.com.br", "iury123", "Iury", "997288193", "37190000", "Três Pontas", "R. José Caixambu Nº 213", "Centro", "UF", 0, 1),
                    new Usuario(2,  "Iury@teste.com.br", "iury123", "Iury", "997288193", "37190000", "Três Pontas", "R. José Caixambu Nº 213", "Centro", "UF", 1, 0)
                });

            builder.Entity<Esportista>()
                .HasData(new List<Esportista>{
                    new Esportista(1, "13131308670"),       
                });
            
            builder.Entity<Comerciante>()
                .HasData(new List<Comerciante>{
                    new Comerciante(1, "Clube do 100", "1222521/0001-01", 1)
                });
                        
        }
    }
}