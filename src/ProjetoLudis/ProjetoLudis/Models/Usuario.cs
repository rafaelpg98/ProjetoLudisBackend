using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLudis.Models
{
    public class Usuario 
    {
        public Usuario(){}

        public Usuario(int id,
                       string email,
                       string senha,
                       string nome,
                       string telefone,
                       string cep,
                       string cidade,
                       string endereco,
                       string bairro,
                       string uf,
                       int idEsportista,
                       int idComerciante
                       )
        {
            this.Id = id;
            this.Email = email;
            this.Senha = senha;
            this.Nome = nome;
            this.Telefone = telefone;
            this.CEP = cep;
            this.Cidade = cidade;
            this.Endereco = endereco;
            this.Bairro = bairro;
            this.UF = uf;
            this.IdEsportista = idEsportista;
            this.IdComerciante = IdComerciante;

        }
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Nome { get; set; }

        public string Complemento { get; set; } = " ";

        public string UF { get; set; }

        public int? IdEsportista { get; set; } = null;
        public Esportista Esportista { get; set; }

        public int? IdComerciante { get; set; } = null;
        public Comerciante Comerciante { get; set; }

    }
}
