using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLudis.Models
{
    public class Esportista
    {
        public Esportista(){}

        public Esportista(int id, string cpf)
        {
            this.Id = id;
            this.CPF = cpf;
        }

        public int Id { get; set; }

        public string CPF { get; set; }
    }
}
